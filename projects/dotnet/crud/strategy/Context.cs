using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strategy
{
    public class Context
    {
        public IPaymentStrategy strategy;
        public Context(IPaymentStrategy strategy)
        {
            this.strategy = strategy;
        }

        public void payment(int amount)
        {
            strategy.pay(amount);
        }
    }
}
