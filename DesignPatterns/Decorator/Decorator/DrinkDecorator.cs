using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public abstract class DrinkDecorator : IDrink
    {
        protected IDrink _drink;
        public DrinkDecorator(IDrink drink)
        {
            _drink = drink;
        }

        public void cost()
        {
            _drink.cost();
        }

        public void Details()
        {
            _drink.Details();
        }
    }
}
