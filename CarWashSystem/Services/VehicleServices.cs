using CarWashSystem.Models;
using CarWashSystem.Repository;

namespace CarWashSystem.Services
{
    internal class VehicleServices
    {
        private JSONVehicleRepository _vehicleRepository;

        public VehicleServices(JSONVehicleRepository vehicleRepository)
        {
            this._vehicleRepository = vehicleRepository;
        }

        internal void AddNewVehicle(string vehicleNumber, Guid id)
        {
            Vehicle vehicle = new Vehicle()
            {
                VehicleNumber = vehicleNumber,
                OwnerId = id,
            };
            this._vehicleRepository.AddVehicle(vehicle);
        }

        internal void DeleteVehicle(string? vehicleNumber, Guid id)
        {
            this._vehicleRepository.RemoveVehicle(vehicleNumber, id);
        }

        internal List<Vehicle> GetUserVehicles(Guid id)
        {
            return this._vehicleRepository.GetAllUserVehicle(id);
        }

        internal bool UpdateVehicle(string? vehicleNumber, Guid id, string? newVehicleNumber)
        {
            if (!this._vehicleRepository.IsVehicleExists(vehicleNumber, id))
            {
                return false;
            }

            this._vehicleRepository.UpdateVehicle(vehicleNumber, id, newVehicleNumber);
            return true;
        }
    }
}