using System.Threading;
using CoffeeShopApp.Models;
using CoffeeShopApp.Repository;

namespace CoffeeShopApp.Services
{
    internal class CoffeeServices
    {
        private readonly List<Machine> machines = new List<Machine>
        {
            new Machine { MachineId = 1, IsAvailable = true },
            new Machine { MachineId = 2, IsAvailable = true },
            new Machine { MachineId = 3, IsAvailable = true }
        };

        private NotificationService notificationService;
        private OrderServices orderServices;
        private InventoryService inventoryService;
        private JsonLogger _logger;
        private readonly SemaphoreSlim semaphoreSlim = new SemaphoreSlim(3, 3);

        public CoffeeServices(NotificationService notificationService, OrderServices orderServices, JsonLogger jsonLogger, InventoryService inventoryService)
        {
            this.notificationService = notificationService;
            this.orderServices = orderServices;
            this._logger = jsonLogger;
            this.inventoryService = inventoryService;
        }

        internal async Task PrepareCoffee(int userChoice, int currentUserId, CancellationToken cts)
        {
            cts.ThrowIfCancellationRequested();

            Order? order = orderServices.FetchOrderDetails(userChoice, currentUserId);
            if (order == null)
            {
                return;
            }
            await StartPreparation(order);
        }

        internal async Task StartPreparation(Order order)
        {
            await semaphoreSlim.WaitAsync();
            Machine? machine = null;
            try
            {
                if (this.inventoryService.ReduceStock(order.CoffeeOrdered))
                {
                    machine = GetFreeMachine(order.OrderId);
                    await _logger.LogAsync(order.UserId, "MachineAssigned", $"Machine {machine.MachineId} assigned to Coffee {order.OrderId}", order.OrderId, machine.MachineId);

                    await _logger.LogAsync(order.UserId, "SourcingStarted", $"Coffee {order.OrderId} sourcing started", order.OrderId, machine.MachineId);
                    notificationService.NotifyUser($"Coffee {order.OrderId} sourcing is started", order.UserId);
                    await Task.Delay(order.CoffeeOrdered.SourcingTime);

                    await _logger.LogAsync(order.UserId, "PreparationStarted", $"Coffee {order.OrderId} preparation started", order.OrderId, machine.MachineId);
                    notificationService.NotifyUser($"Coffee {order.OrderId} preparation is started", order.UserId);
                    await Task.Delay(order.CoffeeOrdered.PreparationTime);

                    await _logger.LogAsync(order.UserId, "CoffeeReady", $"Coffee {order.OrderId} is ready for delivery", order.OrderId, machine.MachineId);
                    notificationService.NotifyUser($"Coffee {order.OrderId} is ready for delivery", order.UserId);
                }
                else 
                {
                    notificationService.NotifyUser($"Coffee {order.OrderId} is cancelled (Insufficient stock)", order.UserId);
                }
            }
            finally
            {
                if (machine != null)
                {
                    notificationService.NotifyUser($"Machine {machine.MachineId} is now free", order.UserId);
                    ReleaseMachine(machine);
                    await _logger.LogAsync(order.UserId, "MachineReleased", $"Machine {machine.MachineId} released after Coffee {order.OrderId}", order.OrderId, machine.MachineId);
                }
                semaphoreSlim.Release();
            }
        }

        private Machine GetFreeMachine(int orderId)
        {
            Machine machine = machines.First(m => m.IsAvailable == true);

            machine.IsAvailable = false;
            machine.OrderId = orderId;

            return machine;
        }
        private void ReleaseMachine(Machine machine)
        {
            machine.IsAvailable = true;
            machine.OrderId = null;
        }
    }
}
