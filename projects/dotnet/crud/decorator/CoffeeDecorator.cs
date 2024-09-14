using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace decorator
{
    public abstract class CoffeeDecorator : ICoffeeComponent
    {
        public ICoffeeComponent _coffeeComponent;
        public CoffeeDecorator(ICoffeeComponent coffeeComponent)
        {
            _coffeeComponent = coffeeComponent;
        }
        public virtual void getCoffee()
        {
            _coffeeComponent.getCoffee();
        }
    }
}
