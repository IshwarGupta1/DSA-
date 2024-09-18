// See https://aka.ms/new-console-template for more information
using builder;

Console.WriteLine("Hello, World!");
var pizzabuilder1 = new PizzaBuilder().setCrust("thin").setPepporoni("yes").setTopping("mushroom").setCheeze("no");
var pizza1 = new PizzaProduct(pizzabuilder1);
Console.WriteLine(pizza1.ToString());

var pizzabuilder2 = new PizzaBuilder().setCrust("thick").setPepporoni("no").setTopping("paneer").setCheeze("yes");
var pizza2 = new PizzaProduct(pizzabuilder2);
Console.WriteLine(pizza2.ToString()); ;
