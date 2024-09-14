using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace decorator
{
    public class MilkDecorator : CoffeeDecorator
    {
        public MilkDecorator(ICoffeeComponent coffeeComponent) : base(coffeeComponent)
        {
        }
        public override void getCoffee()
        {
            base.getCoffee();
            Console.WriteLine(" with milk");
        }
    }
}
