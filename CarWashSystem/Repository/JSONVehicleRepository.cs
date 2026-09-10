using System.Text.Json;
using CarWashSystem.Models;

namespace CarWashSystem.Repository
{
    internal class JSONVehicleRepository
    {
        private readonly List<Vehicle> _vehicle = new List<Vehicle>();

        private readonly string _filepath;

        private readonly JsonSerializerOptions _options = new JsonSerializerOptions()
        {
            WriteIndented = true,
        };

        internal JSONVehicleRepository(string filepath)
        {
            this._filepath = filepath;
            this._vehicle = this.LoadAll();
        }

        internal void AddVehicle(Vehicle vehicle)
        {
            this._vehicle.Add(vehicle);
            this.WriteAll();
        }

        internal bool RemoveVehicle(string vehicleNumber, Guid ownerId)
        {
            if (this.IsVehiclesEmpty(ownerId))
            {
                return false;
            }

            foreach (var vehicle in this._vehicle)
            {
                if (vehicle.VehicleNumber == vehicleNumber && vehicle.OwnerId == ownerId)
                {
                    this._vehicle.Remove(vehicle);
                    break;
                }
            }

            this.WriteAll();
            return true;
        }

        internal bool UpdateVehicle(string vehicleNumber, Guid id, string newVehicleNumber)
        {
            if (this.IsVehiclesEmpty(id))
            {
                return false;
            }

            Vehicle? existing = this._vehicle.FirstOrDefault(vehicle => vehicle.VehicleNumber == vehicleNumber && vehicle.OwnerId == id);
            if (existing != null)
            {
                existing.VehicleNumber = newVehicleNumber;
            }

            this.WriteAll();
            return true;
        }

        internal Vehicle? GetVehicleByNumber(string vehicleNumber)
        {
            return this._vehicle.FirstOrDefault(v => v.VehicleNumber == vehicleNumber);
        }

        internal bool IsVehiclesEmpty(Guid id)
        {
            if (this._vehicle.Where(vehicle => vehicle.OwnerId == id).Count() == 0)
            {
                return true;
            }

            return false;
        }

        internal List<Vehicle> GetAllUserVehicle(Guid id)
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            foreach (Vehicle vehicle in this._vehicle)
            {
                if (vehicle.OwnerId == id)
                {
                    vehicles.Add(vehicle);
                }
            }

            return vehicles;
        }

        internal bool IsVehicleExists(string? vehicleNumber, Guid id)
        {
            return this._vehicle.Where(vehicle => vehicle.VehicleNumber == vehicleNumber && vehicle.OwnerId == id).Count() == 1;
        }

        private void WriteAll()
        {
            string fileData = JsonSerializer.Serialize(this._vehicle, this._options);
            File.WriteAllText(this._filepath, fileData);
        }

        private List<Vehicle> LoadAll()
        {
            if (!File.Exists(this._filepath))
            {
                return new List<Vehicle>();
            }

            string fileData = File.ReadAllText(this._filepath);
            return JsonSerializer.Deserialize<List<Vehicle>>(fileData, this._options) ?? new List<Vehicle>();
        }
    }
}