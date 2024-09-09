using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public class FactoryAnimal
    {
        public IProduct IdentifyAnimal(string animal)
        {
            if (animal == "dog")
                return new ConcreteFactory1();
            return new ConcreteFactory2();

        }
    }
}
