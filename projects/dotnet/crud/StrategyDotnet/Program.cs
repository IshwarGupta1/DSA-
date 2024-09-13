// See https://aka.ms/new-console-template for more information
using StrategyDotnet;

Console.WriteLine("Hello, World!");
Context context1 = new Context(new ConcreteStrategyA());
Context context2 = new Context(new ConcreteStrategyB());
context1.ExecuteStrategy();
context2.ExecuteStrategy();
