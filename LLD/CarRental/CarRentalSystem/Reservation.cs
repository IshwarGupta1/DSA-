using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem
{
    internal class Reservation
    {
        private Dictionary<Car, DateTime> bookLogs;
        private readonly double lateFees = 100.0;
        public Reservation(Dictionary<Car, DateTime> bookLogs)
        {
            this.bookLogs = new Dictionary<Car, DateTime>();
        }

        public void makeReservation(Car car)
        {
            lock(bookLogs)
            {
                if (car.availability == Availability.Booked)
                {
                    throw new InvalidOperationException("car is booked");
                }
                car.availability = Availability.Booked;
                bookLogs.Add(car, DateTime.UtcNow);
                return;
            } 
        }
        public void endReservation(Car car)
        {
            lock(bookLogs)
            {
                car.availability = Availability.Available;
                var duration = (DateTime.UtcNow - bookLogs[car]).Days;
                bookLogs.Remove(car);
                var fees = 0.0;
                if(duration > 10)
                {
                    fees = amountFee(car.RentalPricePerDay, duration, lateFees);
                }
                else
                    fees = amountFee(car.RentalPricePerDay, duration);
                Console.WriteLine($"your reservation ends. Please pay INR {fees}");
                return;
            }
        }
        
        private double amountFee(double rate, int days, double lateFees = 0)
        {
            return (rate * days) + lateFees;
        }
    }
}
