using System;
					
public class Program
{
	public static void Main()
	{
		Console.WriteLine("Hello World");
		var p = new Person();
		p.DisplayFullName();
		p.DisplayAge();
	}
}
// Partial class declaration
public partial class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    // Method in the first part
    public void DisplayFullName()
    {
        Console.WriteLine($"Full Name: {FirstName} {LastName}");
    }
}

// Partial class declaration
public partial class Person
{
    public int Age { get; set; }

    // Method in the second part
    public void DisplayAge()
    {
        Console.WriteLine($"Age: {Age}");
    }
}

