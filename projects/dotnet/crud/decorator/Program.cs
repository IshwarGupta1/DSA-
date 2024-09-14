// See https://aka.ms/new-console-template for more information
using decorator;

Console.WriteLine("Hello, World!");

var plainCoffee = new CoffeeComponent();
plainCoffee.getCoffee();
var milkCoffee = new MilkDecorator(plainCoffee);
milkCoffee.getCoffee();
var creamCoffee = new CreamDecorator(plainCoffee);
creamCoffee.getCoffee();
var mixCoffee = new CreamDecorator(milkCoffee);
mixCoffee.getCoffee();

