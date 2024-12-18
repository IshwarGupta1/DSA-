using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace factory
{
    public class Square : IShape
    {
        public void draw()
        {
            Console.WriteLine("Square it is");
        }
    }
}
