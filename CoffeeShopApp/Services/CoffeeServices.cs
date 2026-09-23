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
        private JsonLogger _logger;
        private readonly SemaphoreSlim semaphoreSlim = new SemaphoreSlim(3, 3);

        public CoffeeServices(NotificationService notificationService, OrderServices orderServices, JsonLogger jsonLogger)
        {
            this.notificationService = notificationService;
            this.orderServices = orderServices;
            this._logger = jsonLogger;
        }

        internal async Task PrepareCoffee(int userChoice)
        {
            Order? order = orderServices.FetchOrderDetails(userChoice);
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
                machine = GetFreeMachine(order.Id);
                await _logger.LogAsync("MachineAssigned", $"Machine {machine.MachineId} assigned to Coffee {order.Id}", order.Id, machine.MachineId);

                await _logger.LogAsync("SourcingStarted", $"Coffee {order.Id} sourcing started", order.Id, machine.MachineId);
                notificationService.NotifyUser($"Coffee {order.Id} sourcing is started");
                await Task.Delay(order.CoffeeOrdered.SourcingTime);

                await _logger.LogAsync("PreparationStarted", $"Coffee {order.Id} preparation started", order.Id, machine.MachineId);
                notificationService.NotifyUser($"Coffee {order.Id} preparation is started");
                await Task.Delay(order.CoffeeOrdered.PreparationTime);

                await _logger.LogAsync("CoffeeReady", $"Coffee {order.Id} is ready for delivery", order.Id, machine.MachineId);
                notificationService.NotifyUser($"Coffee {order.Id} is ready for delivery");
            }
            finally
            {
                if (machine != null)
                {
                    notificationService.NotifyUser($"Machine {machine.MachineId} is now free");
                    ReleaseMachine(machine);
                    await _logger.LogAsync("MachineReleased", $"Machine {machine.MachineId} released after Coffee {order.Id}", order.Id, machine.MachineId);
                }
                semaphoreSlim.Release();
            }
        }
        private Machine GetFreeMachine(int orderId)
        {
            Machine machine = machines.First(m => m.IsAvailable);

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
