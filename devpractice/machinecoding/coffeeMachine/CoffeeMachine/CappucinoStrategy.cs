using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine
{
    public class CappucinoStrategy : CoffeeStrategy
    {
        public void makeCoffee()
        {
            var plainCoffee = new Coffee();
            var cappucino = new SugarDecorator(new MilkDecorator(plainCoffee));
            cappucino.getDescription();
            cappucino.getPrice();
        }
    }
}
