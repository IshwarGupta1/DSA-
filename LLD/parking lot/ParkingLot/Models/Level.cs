using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Models
{
    internal class Level
    {
        private readonly int _levelNo;
        private readonly List<ParkingSpot> _parkingSpots = new List<ParkingSpot>();
        public Level(int levelNo, int numSpots)
        {
            _levelNo = levelNo;
            double spotsForBikes = 0.50;
            double spotsForCars = 0.40;

            int numBikes = (int)(numSpots * spotsForBikes);
            int numCars = (int)(numSpots * spotsForCars);

            for (int i = 1; i <= numBikes; i++)
            {
                _parkingSpots.Add(new ParkingSpot(i, VehicleType.Bike));
            }
            for (int i = numBikes + 1; i <= numBikes + numCars; i++)
            {
                _parkingSpots.Add(new ParkingSpot(i, VehicleType.Car));
            }
            for (int i = numBikes + numCars + 1; i <= numSpots; i++)
            {
                _parkingSpots.Add(new ParkingSpot(i, VehicleType.Truck));
            }
        }

        public bool ParkVehicle(Vehicle vehicle)
        {
            lock(_parkingSpots)
            {
                foreach(var spot in  _parkingSpots)
                {
                    if(spot.isAvailable() && spot.GetVehicleType()== vehicle._vehicleType)
                    {
                        spot.parkVehicle(vehicle);
                        return true;
                    }
                }
            }
            return false;
        }

        public bool UnParkVehicle(Vehicle vehicle)
        {
            lock(_parkingSpots)
            {
                foreach( var spot in _parkingSpots)
                {
                    if(!spot.isAvailable() && spot.GetVehicle()==vehicle)
                    {
                        spot.unparkVehicle();
                        return true;
                    }
                }
            }
            return false;
        }

        public void DisplayAvailability()
        {
            Console.WriteLine($"Level {_levelNo} Availability:");
            foreach (var spot in _parkingSpots)
            {
                Console.WriteLine($"Spot {spot.GetSpotNo}: {(spot.isAvailable() ? "Available For" : "Occupied By")} {spot.GetVehicleType()}");
            }
        }
    }
}
