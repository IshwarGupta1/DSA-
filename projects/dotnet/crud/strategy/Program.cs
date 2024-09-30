// See https://aka.ms/new-console-template for more information
using strategy;

Console.WriteLine("Hello, World!");
var context1 = new Context(new CashStrategy());
var context2 = new Context(new CreditCardStrategy());
var context3 = new Context(new UPIStrategy());
context1.payment(100);
context2.payment(1000);
context3.payment(10000);

