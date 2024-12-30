using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine
{
    public class SugarDecorator : CoffeeDecorator
    {
        public SugarDecorator(Coffee coffee) : base(coffee)
        {
        }
        public override string getDescription()
        {
            return base.getDescription() + ", sugar added";
        }

        public override double getPrice()
        {
            return base.getPrice() + 3.0;
        }
    }
}
