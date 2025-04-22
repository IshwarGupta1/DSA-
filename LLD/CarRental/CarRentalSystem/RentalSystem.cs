using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem
{
    internal class RentalSystem
    {
        private List<Car> cars;
        private readonly Reservation reservation;
        public RentalSystem(List<Car> cars, Reservation reservation)
        {
            this.cars = cars;
            this.reservation = reservation;
        }

        public void AddCar(Car car)
        {
            cars.Add(car);
        }

        public void RemoveCar(Car car)
        {
            cars.Remove(car);
        }

        public void searchCar(string searchType, object val)
        {
            if (searchType == "Year")
            {
                foreach (var car in cars)
                {
                    if (car.Year == (int)val)
                        Console.WriteLine($"Car is {car.Model} and it is {car.availability}");
                }
            }
            else if (searchType == "Model")
            {
                foreach (var car in cars)
                {
                    if (car.Year == (int)val)
                        Console.WriteLine($"Car is of year {car.Year} and it is {car.availability}");
                }
            }
        }

        public void bookCar(Car car)
        {
            if (!cars.Contains(car))
                throw new Exception("This car is not available");
            reservation.makeReservation(car);
        }

        public void submitCar(Car car)
        {
            reservation.endReservation(car);
        }
    }
}
