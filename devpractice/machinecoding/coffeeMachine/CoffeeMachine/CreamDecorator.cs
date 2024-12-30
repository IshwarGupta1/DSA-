using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine
{
    public class CreamDecorator : CoffeeDecorator
    {
        public CreamDecorator(Coffee coffee) : base(coffee)
        {
        }
        public override string getDescription()
        {
            return base.getDescription() + ", cream added";
        }

        public override double getPrice()
        {
            return base.getPrice() + 6.5;
        }
    }
}
