using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace builder
{
    public class PizzaProduct
    {
        private string crust;
        private string cheeze;
        private string topping;
        private string pepporoni;
        public PizzaProduct(PizzaBuilder builder)
        {
            crust = builder.Crust;
            cheeze = builder.Cheeze;
            topping = builder.Topping;
            pepporoni = builder.Pepporoni;
        }
        public override string ToString()
        {
            return $"Pizza with {crust} crust, {cheeze} cheeze, {topping} topping, and {pepporoni} pepporoni.";
        }
    }
}
