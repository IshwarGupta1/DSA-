using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine
{
    public class MilkDecorator : CoffeeDecorator
    {
        public MilkDecorator(Coffee coffee) : base(coffee)
        {
        }
        public override string getDescription()
        {
            return base.getDescription()+", milk added";
        }

        public override double getPrice()
        {
            return base.getPrice() + 5.0;
        }
    }
}
