// See https://aka.ms/new-console-template for more information
using Singleton;

Console.WriteLine("Hello, World!");
var hash1 = HashInstance.getInstance();
var hash2 = HashInstance.getInstance();
Console.WriteLine(hash1==hash2);
