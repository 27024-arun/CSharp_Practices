using CoffeeShopApp.Models;

namespace CoffeeShopApp.Services
{
    internal class OrderServices
    {
        private static int _orderId = 0;
        internal Order? FetchOrderDetails(int userChoice)
        {
            switch(userChoice)
            {
                case 1:
                    return new Order(
                        ++_orderId, 
                        new Coffee((CoffeeMenuOption)userChoice, System.TimeSpan.FromSeconds(3), System.TimeSpan.FromSeconds(2)));
                case 2:
                    return new Order(
                        ++_orderId, 
                        new Coffee((CoffeeMenuOption)userChoice, System.TimeSpan.FromSeconds(4), System.TimeSpan.FromSeconds(3)) );
                case 3:
                    return new Order(
                        ++_orderId, 
                        new Coffee((CoffeeMenuOption)userChoice, System.TimeSpan.FromSeconds(5), System.TimeSpan.FromSeconds(2)) );
                case 4:
                    return new Order(
                        ++_orderId, 
                        new Coffee((CoffeeMenuOption)userChoice, System.TimeSpan.FromSeconds(5), System.TimeSpan.FromSeconds(3)) );
                default:
                    return null;
            }
        }
    }
}
