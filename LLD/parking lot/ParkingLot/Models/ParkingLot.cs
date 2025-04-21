using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Models
{
    internal class ParkingLot
    {
        private static ParkingLot? instance;
        private readonly List<Level> levels;

        private ParkingLot()
        {
            levels = new List<Level>();
        }

        public static ParkingLot GetInstance()
        {
            if (instance == null)
            {
                instance = new ParkingLot();
            }
            return instance;
        }

        public void AddLevel(Level level)
        {
            levels.Add(level);
        }

        public bool ParkVehicle(Vehicle vehicle)
        {
            foreach (var level in levels)
            {
                if (level.ParkVehicle(vehicle))
                {
                    Console.WriteLine("Vehicle parked successfully.");
                    return true;
                }
            }
            Console.WriteLine("Could not park vehicle.");
            return false;
        }

        public bool UnparkVehicle(Vehicle vehicle)
        {
            foreach (var level in levels)
            {
                if (level.UnParkVehicle(vehicle))
                {
                    return true;
                }
            }
            return false;
        }

        public void DisplayAvailability()
        {
            foreach (var level in levels)
            {
                level.DisplayAvailability();
            }
        }
    }
}
