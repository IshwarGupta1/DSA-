using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public class Latte : IDrink
    {
        public int _cost;
        public Latte(int cost)
        {
            _cost = cost;
        }
        public void cost()
        {
            Console.WriteLine($"Cost of Simple Latte is {_cost}");
        }

        public void Details()
        {
            Console.WriteLine("This is a latte");
        }
    }
}
