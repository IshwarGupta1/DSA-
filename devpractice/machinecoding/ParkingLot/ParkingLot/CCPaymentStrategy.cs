using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class CCPaymentStrategy : paymentStrategy
    {
        public void pay(double amount)
        {
            Console.WriteLine($"Credit Card paid {amount}");
        }
    }
}
