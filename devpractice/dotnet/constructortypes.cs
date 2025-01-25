using System;
					
public class Program
{
	public static void Main()
	{
		var prac1 = new practice();
		var prac2 = new practice(10,11);
		var prac3 = new practice(prac1);
	}
}

public class practice
{
	private int x = 3;
	static int q=3;
	static int r=3;
	public practice()
	{
		Console.WriteLine(3+2);
	}
	public practice(int a, int b)
	{
		Console.WriteLine(a+b);
	}
	public practice(practice obj)
	{
		x=obj.x;
		Console.WriteLine(x);
	}
	static practice()
	{
		Console.WriteLine(q+r);
	}
}