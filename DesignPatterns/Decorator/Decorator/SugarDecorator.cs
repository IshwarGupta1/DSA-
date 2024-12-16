using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public class SugarDecorator : DrinkDecorator
    {
        public SugarDecorator(IDrink drink) : base(drink)
        {

        }

        public void cost()
        {
            base.cost();
            Console.WriteLine("Cost is increased by 5 Rs");
        }

        public void Details()
        {
            base.Details();
            Console.WriteLine("Sugar is added 1 packet");
        }
    }
}
