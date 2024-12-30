namespace CoffeeMachine
{
    public class LatteStrategy : CoffeeStrategy
    {
        public void makeCoffee()
        {
            var plainCoffee = new Coffee();
            var latte = new CreamDecorator(new MilkDecorator(plainCoffee));
            latte.getDescription();
            latte.getPrice();
        }
    }
}
