using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace factory
{
    public class Circle : IShape
    {
        public void draw()
        {
            Console.WriteLine("circle it is");
        }
    }
}
