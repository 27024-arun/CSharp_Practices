using CarWashSystem.Repository;
using CarWashSystem.Services;
using CarWashSystem.View;

namespace Assignments
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            JSONUserRepository userRepository = new JSONUserRepository("Users.json");
            JSONVehicleRepository vehicleRepository = new JSONVehicleRepository("Vehicles.json");

            UserServices userServices = new UserServices(userRepository);
            VehicleServices vehicleServices = new VehicleServices(vehicleRepository);
            VehicleWashServices vehicleWashServices = new VehicleWashServices(vehicleRepository);

            CarView carView = new CarView(vehicleServices, vehicleWashServices);
            LogInView loginView = new LogInView(userServices, carView);
            SignUpView signupView = new SignUpView(userServices);

            while (true)
            {
                Console.Clear();
                string userMainMenu = $@"
Vehicle Wash System
[L]ogin
[S]ignup";
                Console.WriteLine(userMainMenu);
                ConsoleKey userChoice = Console.ReadKey().Key;
                switch (userChoice)
                {
                    case ConsoleKey.L:
                        loginView.LogInMenu();
                        break;
                    case ConsoleKey.S:
                        signupView.SignUpMenu();
                        break;
                    default:
                        Console.WriteLine("Invalid data");
                        break;
                }
            }
        }
    }
}