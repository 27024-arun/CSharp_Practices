using CoffeeShopApp.Models;
using CoffeeShopApp.Services;

namespace CoffeeShopApp.View
{
    internal class CoffeeView
    {
        private CoffeeServices coffeeServices;

        public CoffeeView(CoffeeServices coffeeServices)
        {
            this.coffeeServices = coffeeServices;
        }

        public void UserMenu()
        {
            Order order = new Order();
            while(true)
            {
                Console.WriteLine($@"
==================================
          Coffee Shop
==================================");
                foreach(var userOptions in Enum.GetValues(typeof(CoffeeMenuOption)))
                {
                    Console.WriteLine($"{(int)userOptions}. {userOptions}");
                }
                Console.Write($"Enter Choice: ");
                int.TryParse(Console.ReadLine(), out int userChoice);

                if(userChoice is 5)
                {
                    return;
                }
                Task prepareCoffee = coffeeServices.PrepareCoffee(userChoice);
            }
        }
    }
}
