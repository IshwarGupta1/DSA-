using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine
{
    public class IngredientsUpdate
    {
        private Dictionary<string, int> ingredients;
        public IngredientsUpdate(Dictionary<string, int> ingredients)
        {
            this.ingredients = ingredients;
        }

        public void Update(Dictionary<string, int> usedIngredients)
        {
            foreach (var item in usedIngredients)
            {
                if (ingredients.ContainsKey(item.Key))
                {
                    ingredients[item.Key] -= item.Value;

                    if (ingredients[item.Key] < 5)
                    {
                        Console.WriteLine($"{item.Key} is going low in quantity");
                    }
                }
            }
        }
    }
}
