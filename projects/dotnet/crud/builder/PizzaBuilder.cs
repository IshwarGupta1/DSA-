using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace builder
{
    public class PizzaBuilder
    {
        public string Crust { get; private set; }
        public string Cheeze { get; private set; }
        public string Topping { get; private set; }
        public string Pepporoni { get; private set; }
        public PizzaBuilder setCrust(string crust)
        {
            Crust = crust;
            return this;
        }

        public PizzaBuilder setCheeze(string cheeze)
        {
            Cheeze = cheeze;
            return this;
        }
        public PizzaBuilder setTopping(string topping)
        {
            Topping = topping;
            return this;
        }
        public PizzaBuilder setPepporoni(string pepporoni)
        {
            Pepporoni = pepporoni;
            return this;
        }

        public PizzaProduct pizza()
        {
            return new PizzaProduct(this);
        }
    }
}
