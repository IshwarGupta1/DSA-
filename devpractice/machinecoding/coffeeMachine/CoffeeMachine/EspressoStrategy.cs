using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine
{
    public class EspressoStrategy : CoffeeStrategy
    {
        public void makeCoffee()
        {
            var plainCoffee = new Coffee();
            var espresso = new CreamDecorator(plainCoffee);
            espresso.getDescription();
            espresso.getPrice();
        }
    }
}
