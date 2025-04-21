using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Models
{
    internal class Bike : Vehicle
    {
        public Bike(string licensePlate, VehicleType vehicleType) : base(licensePlate, vehicleType) { }
    }
}
