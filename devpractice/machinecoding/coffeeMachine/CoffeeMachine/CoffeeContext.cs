using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine
{
    public class CoffeeContext
    {
        public CoffeeContext()
        {
        }
        public void makeCoffee(CoffeeStrategy strategy)
        {
            strategy.makeCoffee();
        }
    }
}
