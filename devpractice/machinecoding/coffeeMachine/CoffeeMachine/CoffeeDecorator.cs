using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine
{
    public class CoffeeDecorator:Coffee
    {
        protected Coffee coffee;
        public CoffeeDecorator(Coffee coffee)
        {
            this.coffee = coffee;
        }

        public override string getDescription()
        {
            return coffee.getDescription();
        }

        public override double getPrice()
        {
            return coffee.getPrice();
        }
    }
}
