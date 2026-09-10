using CarWashSystem.Models;
using CarWashSystem.Services;

namespace CarWashSystem.View
{
    internal class CarView
    {
        private VehicleServices _vehicleServices;
        private VehicleWashServices _vehicleWashServices;
        private User _currentUser;

        public CarView(VehicleServices vehicleServices, VehicleWashServices vehicleWashServices)
        {
            this._vehicleServices = vehicleServices;
            this._currentUser = new User();
            this._vehicleWashServices = vehicleWashServices;
            this._vehicleWashServices.CarServiced += this.CarServicedMessage;
        }

        public void ShowUserCars()
        {
            while (true)
            {
                string userCarMenu = $@"
Car Service Options
1. Add New Vehicle
2. View User Vehicles
3. Remove Vehicle
4. Update Vehicle data
5. Service Vehicle
6. Return to main menu:";
                Console.WriteLine(userCarMenu);
                int.TryParse(Console.ReadLine(), out int userChoice);

                switch (userChoice)
                {
                    case 1:
                        this.AddNewVehicle();
                        break;
                    case 2:
                        this.DisplayVehicle();
                        break;
                    case 3:
                        this.DeleteVehicle();
                        break;
                    case 4:
                        this.UpdateVehicle();
                        break;
                    case 5:
                        this.ServiceVehicle();
                        break;
                    case 6:
                        this._currentUser = null;
                        return;
                    default:
                        Console.WriteLine("Invalid data");
                        break;
                }
            }
        }

        internal void AssignCurrentUser(User? user)
        {
            this._currentUser = user;
        }

        private void DisplayVehicle()
        {
            List<Vehicle> vehicles = this._vehicleServices.GetUserVehicles(this._currentUser.Id);
            foreach (Vehicle vehicle in vehicles)
            {
                Console.WriteLine($"{vehicle.VehicleNumber}");
            }
        }

        private void AddNewVehicle()
        {
            Console.WriteLine("Enter Vehicle Number");
            string vehicleNumber = Console.ReadLine();
            this._vehicleServices.AddNewVehicle(vehicleNumber, this._currentUser.Id);
        }

        private void DeleteVehicle()
        {
            Console.WriteLine("Enter Vehicle Number");
            string vehicleNumber = Console.ReadLine();
            this._vehicleServices.DeleteVehicle(vehicleNumber, this._currentUser.Id);
        }

        private void UpdateVehicle()
        {
            Console.WriteLine("Enter Vehicle Number");
            string vehicleNumber = Console.ReadLine();

            Console.WriteLine("Enter New Number for the vehicle");
            string newVehicleNumber = Console.ReadLine();
            bool updated = this._vehicleServices.UpdateVehicle(vehicleNumber, this._currentUser.Id, newVehicleNumber);
            if (updated)
            {
                Console.Write("Updated");
            }
            else
            {
                Console.WriteLine("Not Updated");
            }
        }

        private void ServiceVehicle()
        {
            List<Vehicle> vehicles = this._vehicleServices.GetUserVehicles(this._currentUser.Id);
            if (vehicles.Count == 0)
            {
                Console.WriteLine("No vehicles found.");
                return;
            }

            Console.WriteLine("\nYour Vehicles:");
            int count = 1;
            foreach (Vehicle vehicle in vehicles)
            {
                Console.WriteLine($"{count}. {vehicle.VehicleNumber}");
                count++;
            }

            Console.Write("\nEnter Vehicle Number to wash: ");
            string vehicleNumber = Console.ReadLine();
            this._vehicleWashServices.ServiceVehicle(vehicleNumber, this._currentUser.Id);
        }

        private void CarServicedMessage(string vehicleNumber, Guid id)
        {
            if (this._currentUser != null && this._currentUser.Id == id)
            {
                Console.WriteLine($"Car {vehicleNumber} is serviced.");
            }
        }
    }
}