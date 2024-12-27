using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class UPIPaymentStrategy : paymentStrategy
    {
        public void pay(double amount)
        {
            Console.WriteLine($"UPI paid {amount}");
        }
    }
}
