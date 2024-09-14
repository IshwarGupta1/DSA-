using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace decorator
{
    public class CoffeeComponent : ICoffeeComponent
    {
        public void getCoffee()
        {
            Console.WriteLine("Get me a normal black coffee");
        }
    }
}
