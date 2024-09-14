using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace decorator
{
    public class CreamDecorator : CoffeeDecorator
    {
        public CreamDecorator(ICoffeeComponent coffeeComponent) : base(coffeeComponent)
        {
        }
        public override void getCoffee()
        {
            base.getCoffee();
            Console.WriteLine(" with cream");
        }
    }
}
