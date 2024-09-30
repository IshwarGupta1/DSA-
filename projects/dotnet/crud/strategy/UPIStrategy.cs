using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strategy
{
    public class UPIStrategy : IPaymentStrategy
    {
        public void pay(int amount)
        {
            Console.WriteLine($"pay via upi {amount}");
        }
    }
}
