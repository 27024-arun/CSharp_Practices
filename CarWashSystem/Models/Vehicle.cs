using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWashSystem.Models
{
    internal class Vehicle
    {
        public Vehicle()
        {
        }

        internal Vehicle(string vehicleNumber, Guid ownerId)
        {
            this.VehicleNumber = vehicleNumber;
            this.OwnerId = ownerId;
        }

        public string VehicleNumber { get; set; }

        public Guid OwnerId { get; set; }
    }
}