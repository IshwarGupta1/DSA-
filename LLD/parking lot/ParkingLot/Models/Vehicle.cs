using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Models
{
    internal class Vehicle
    {
        public string _licensePlate { get; set; }
        public VehicleType _vehicleType { get; set; }

        public Vehicle(string licensePlate, VehicleType vehicleType)
        {
            _licensePlate = licensePlate;
            _vehicleType = vehicleType;
        }
    }
}
