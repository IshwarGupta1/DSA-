using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public class Espresso : IDrink
    {
        public int _cost;
        public Espresso(int cost)
        {
            _cost = cost;
        }
 
        public void cost()
        {
            Console.WriteLine($"Cost of simple Espresso is {_cost}");
        }

        public void Details()
        {
            Console.WriteLine("This is an espresso");
        }
    }
}
