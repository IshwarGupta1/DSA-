using ConsoleApp1.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Context
    {
        private IPay _payStrategy;
        public Context(IPay payStrategy)
        {
            _payStrategy = payStrategy;
        }

        public void doPayment(int amount)
        {
            if (_payStrategy == null)
            {
                throw new InvalidOperationException("Payment strategy not set.");
            }
            _payStrategy.Pay(amount);
        }

    }
}
