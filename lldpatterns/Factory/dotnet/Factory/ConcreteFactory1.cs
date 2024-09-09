using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public class ConcreteFactory1:IProduct
    {
        public void Animal()
        {
            Console.WriteLine("dog is barking");
        }
    }
}
