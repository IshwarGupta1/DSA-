using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem
{
    internal class Car
    {
        public string Model { get; set; }
        public int Year { get; set; }
        public string LicensePlate { get; set; }
        public double RentalPricePerDay { get; set; }
        public Availability availability { get; set; }

        public Car(string model, int year, string licensePlate, double rentalPricePerDay, Availability availability)
        {
            Model = model;
            Year = year;
            LicensePlate = licensePlate;
            RentalPricePerDay = rentalPricePerDay;
            this.availability = availability;
        }
    }
}
