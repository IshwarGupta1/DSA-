namespace CoffeeMachine
{
    public class CreateCoffee
    {
        private List<string> coffeeList;
        private Dictionary<string, int> ingredients;
        private CoffeeContext context;
        private IngredientsUpdate ingredientsUpdate;

        public CreateCoffee(List<string> coffeeList, Dictionary<string, int> ingredients, CoffeeContext context, IngredientsUpdate ingredientsUpdate)
        {
            this.coffeeList = coffeeList;
            this.ingredients = ingredients;
            this.context = context;
            this.ingredientsUpdate = ingredientsUpdate;
        }

        public void displayAllOptions()
        {
            foreach(var coffee in coffeeList) { 
                Console.WriteLine(coffee);
            }
        }

        public void makeCoffee(string coffee)
        {
            switch(coffee)
            {
                case "Cappucino":
                    context.makeCoffee(new CappucinoStrategy());
                    var used1 = new Dictionary<string, int>();
                    used1.Add("coffee", 1);
                    used1.Add("milk", 1);
                    used1.Add("sugar", 1);
                    ingredientsUpdate.Update(used1);
                    break;
                case "Latte":
                    context.makeCoffee(new LatteStrategy());
                    var used2 = new Dictionary<string, int>();
                    used2.Add("coffee", 1);
                    used2.Add("milk", 1);
                    ingredientsUpdate.Update(used2);
                    break;
                case "Espresso":
                    context.makeCoffee(new EspressoStrategy());
                    var used3 = new Dictionary<string, int>();
                    used3.Add("coffee", 1);
                    used3.Add("cream", 1);
                    ingredientsUpdate.Update(used3);
                    break;
            }
        }
    }
}
