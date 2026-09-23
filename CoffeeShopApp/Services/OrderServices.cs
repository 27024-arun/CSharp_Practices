using CoffeeShopApp.Models;

namespace CoffeeShopApp.Services
{
    internal class OrderServices
    {
        private static int _orderId = 0;
        internal Order? FetchOrderDetails(int userChoice, int userId)
        {
            switch(userChoice)
            {
                case 1:
                    return new Order(
                        ++_orderId, 
                        new Coffee((CoffeeMenuOption)userChoice, System.TimeSpan.FromSeconds(3), System.TimeSpan.FromSeconds(2)),
                        userId);
                case 2:
                    return new Order(
                        ++_orderId, 
                        new Coffee((CoffeeMenuOption)userChoice, System.TimeSpan.FromSeconds(4), System.TimeSpan.FromSeconds(3)),
                        userId);
                case 3:
                    return new Order(
                        ++_orderId, 
                        new Coffee((CoffeeMenuOption)userChoice, System.TimeSpan.FromSeconds(5), System.TimeSpan.FromSeconds(2)),
                        userId);
                case 4:
                    return new Order(
                        ++_orderId, 
                        new Coffee((CoffeeMenuOption)userChoice, System.TimeSpan.FromSeconds(5), System.TimeSpan.FromSeconds(3)),
                        userId);
                default:
                    return null;
            }
        }
    }
}
