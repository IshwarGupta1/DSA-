// See https://aka.ms/new-console-template for more information
using EmployeeManagement;

Console.WriteLine("Hello, World!");
var emp1 = new Manager("DP", "Emp1", 1);
var emp2 = new Developer("C#", "Emp2", 2);
emp1.workToDo();
emp2.workToDo();
