using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strategy
{
    public class CreditCardStrategy : IPaymentStrategy
    {
        public void pay(int amount)
        {
            Console.WriteLine($"pay via credit card {amount}");
        }
    }
}
