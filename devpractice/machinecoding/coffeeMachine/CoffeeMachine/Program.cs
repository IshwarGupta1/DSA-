// See https://aka.ms/new-console-template for more information
using CoffeeMachine;

Console.WriteLine("Hello, World!");
List<string> coffeeList = new List<string> { "Cappucino", "Latte", "Espresso" };
Dictionary<string, int> ingredients = new Dictionary<string, int>
            {
                { "coffee", 10 },
                { "milk", 10 },
                { "sugar", 10 },
                { "cream", 10 }
            };

// Instantiate context and ingredients update
CoffeeContext context = new CoffeeContext();
IngredientsUpdate ingredientsUpdate = new IngredientsUpdate(ingredients);

// Create coffee machine
CreateCoffee coffeeMachine = new CreateCoffee(coffeeList, ingredients, context, ingredientsUpdate);

// Main menu loop
while (true)
{
    Console.WriteLine("\nWelcome to the Coffee Machine!");
    Console.WriteLine("Here are the available options:");
    coffeeMachine.displayAllOptions();
    Console.WriteLine("Type the name of the coffee you want or type 'exit' to quit.");

    string userChoice = Console.ReadLine();

    if (userChoice.Equals("exit", StringComparison.OrdinalIgnoreCase))
    {
        Console.WriteLine("Thank you for using the Coffee Machine. Goodbye!");
        break;
    }

    if (coffeeList.Contains(userChoice))
    {
        Console.WriteLine($"Preparing your {userChoice}...");
        coffeeMachine.makeCoffee(userChoice);
        Console.WriteLine($"Your {userChoice} is ready. Enjoy!");
    }
    else
    {
        Console.WriteLine("Invalid selection. Please choose a valid coffee type.");
    }
}
