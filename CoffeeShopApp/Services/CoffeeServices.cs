using CoffeeShopApp.Models;

namespace CoffeeShopApp.Services
{
    internal class CoffeeServices
    {
        private NotificationService notificationService;
        private OrderServices orderServices;

        public CoffeeServices(NotificationService notificationService, OrderServices orderServices)
        {
            this.notificationService = notificationService;
            this.orderServices = orderServices;
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
            notificationService.NotifyUser($"Coffee {order.Id} sourcing is started");
            await Task.Delay(order.CoffeeOrdered.SourcingTime);
            notificationService.NotifyUser($"Coffee {order.Id} preparation is started");
            await Task.Delay(order.CoffeeOrdered.PreparationTime);
            notificationService.NotifyUser($"Coffee {order.Id} is ready for delivery");
        }
    }
}
