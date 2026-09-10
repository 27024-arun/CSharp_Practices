using System.Timers;
using CarWashSystem.Models;
using CarWashSystem.Repository;

namespace CarWashSystem.Services
{
    internal class VehicleWashServices
    {
        private const int MaximumCars = 3;

        private readonly JSONVehicleRepository _vehicleRepository;

        private readonly List<string> _washingCars = new List<string>();

        public VehicleWashServices(JSONVehicleRepository vehicleRepository)
        {
            this._vehicleRepository = vehicleRepository;
        }

        public event Action<string, Guid> CarServiced;

        internal void ServiceVehicle(string vehicleNumber, Guid userId)
        {
            Vehicle? vehicle = this._vehicleRepository.GetVehicleByNumber(vehicleNumber);

            if (vehicle == null)
            {
                Console.WriteLine("Vehicle not found.");
                return;
            }

            if (vehicle.OwnerId != userId)
            {
                Console.WriteLine("This vehicle does not belong to you.");
                return;
            }

            if (this._washingCars.Contains(vehicleNumber))
            {
                Console.WriteLine($"Car {vehicleNumber} is already washing.");
                return;
            }

            if (this._washingCars.Count >= MaximumCars)
            {
                Console.WriteLine("Maximum 3 cars are being washed now.");
                return;
            }

            this._washingCars.Add(vehicleNumber);

            Console.WriteLine($"\nCar {vehicleNumber} is washing now.");

            Console.WriteLine($"Washing Cars: {this._washingCars.Count}/3");

            System.Timers.Timer timer = new System.Timers.Timer(20000);

            timer.AutoReset = false;

            timer.Elapsed += (sender, e) =>
            {
                this._washingCars.Remove(vehicleNumber);

                this.CarServiced?.Invoke(vehicleNumber, userId);

                timer.Dispose();
            };

            timer.Start();
        }
    }
}