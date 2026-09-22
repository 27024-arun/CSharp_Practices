using CoffeeShopApp.Services;
using CoffeeShopApp.View;

namespace CoffeeShopApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NotificationService notificationService = new NotificationService();
            NotificationView notificationView = new NotificationView(notificationService);

            OrderServices orderServices = new OrderServices();

            CoffeeServices coffeeServices = new CoffeeServices(notificationService, orderServices);
            CoffeeView coffeeView = new CoffeeView(coffeeServices);

            coffeeView.UserMenu();
            Console.WriteLine($"Thanks for visiting!");
            Thread.Sleep(1300);
        }
    }
}
