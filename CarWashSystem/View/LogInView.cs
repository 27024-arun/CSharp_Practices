using System.Runtime.CompilerServices;
using CarWashSystem.Models;
using CarWashSystem.Services;
using CarWashSystem.View;

namespace CarWashSystem.View
{
    internal class LogInView
    {
        private readonly UserServices _userServices;
        private readonly CarView _carView;

        public LogInView(UserServices userServices, CarView carView)
        {
            this._userServices = userServices;
            this._carView = carView;
        }

        public void LogInMenu()
        {
            Console.Clear();
            Console.WriteLine("----------LogIn Menu----------");
            int phone = ViewHelper.GetIntData("Phone");
            if (phone == 0)
            {
                ViewHelper.WriteColored("\nReturning to main menu...", ConsoleColor.Yellow);
                Thread.Sleep(1500);
                return;
            }

            string? password = ViewHelper.GetStringData("Password");
            if (string.IsNullOrEmpty(password))
            {
                ViewHelper.WriteColored("\nReturning to main menu...", ConsoleColor.Yellow);
                Thread.Sleep(1500);
                return;
            }

            bool isUserExists = this._userServices.CheckUserExists(phone, password);
            if (isUserExists)
            {
                User user = this._userServices.GetUserId(phone, password);
                this._carView.AssignCurrentUser(user);
                Console.Clear();
                Console.WriteLine("Logged In.");
                this._carView.ShowUserCars();
            }
            else
            {
                Console.WriteLine("Entered data is invalid.");
            }

            Console.WriteLine("\nEnter any key to return to main menu");
            Console.ReadKey();
        }
    }
}