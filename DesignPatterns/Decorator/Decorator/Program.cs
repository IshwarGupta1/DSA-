// See https://aka.ms/new-console-template for more information
using Decorator;
using System.Linq.Expressions;

Console.WriteLine("Hello, World!");
var drink1 = new Espresso(10);
var drink2 = new Latte(5);
var decorator1 = new MilkDecorator(drink1);
var decorator2 = new MilkDecorator(drink2);
var decorator3 = new SugarDecorator(drink1);
decorator1.cost();
decorator2.cost();
decorator3.cost();

