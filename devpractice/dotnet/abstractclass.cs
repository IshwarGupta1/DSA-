using System;
					
public class Program
{
	public static void Main()
	{
		Console.WriteLine("Hello World");
		var d = new dog();
		d.name = "bruno";
		d.bark();
	}
}
public abstract class animal
{
	public abstract string name {get ; set ;}
	public abstract void bark();
	public void wing()
	{
		Console.WriteLine("wing");
	}
}
public class dog : animal
{
	public override string name {get; set;}
	public override void bark()
	{
		Console.WriteLine("bark");
	}
}
