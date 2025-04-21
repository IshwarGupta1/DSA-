using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Models
{
    internal class ParkingSpot
    {
        private readonly int _spotNo;
        private readonly VehicleType _vehicleType;
        private Vehicle _parkedVehicle;
        public ParkingSpot(int spotNo, VehicleType vehicleType)
        {
            _spotNo = spotNo;
            _vehicleType = vehicleType;
        }   

        public bool isAvailable()
        {
            return _parkedVehicle == null;
        }

        public void parkVehicle(Vehicle vehicle)
        {
            if (isAvailable() && _vehicleType == vehicle._vehicleType)
            {
                _parkedVehicle = vehicle;
            }
            else
            {
                throw new ArgumentException("Invalid Vehicle to be parked or spot is already occupied");
            }
        }

        public void unparkVehicle()
        {
            if (_parkedVehicle != null)
            {
                _parkedVehicle = null;
            }
            else
            { 
                throw new ArgumentException("already free");
            }
        }

        public VehicleType GetVehicleType()
        {
            return _vehicleType;
        }

        public Vehicle GetVehicle()
        {
            return _parkedVehicle;
        }

        public int GetSpotNo()
        { return _spotNo; }
    }

}
