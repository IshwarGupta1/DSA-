using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public class MilkDecorator : DrinkDecorator
    {
        public MilkDecorator(IDrink drink) : base(drink)
        {

        }

        public void cost()
        {
            base.cost();
            Console.WriteLine("Cost is increased by 10 Rs");
        }

        public void Details()
        {
            base.Details();
            Console.WriteLine("Milk is added 1 glass");
        }
    }
}
