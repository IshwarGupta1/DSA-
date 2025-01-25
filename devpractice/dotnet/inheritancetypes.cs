using System;
					
public class Program
{
	public static void Main()
	{
		Console.WriteLine("Hello World");
		var obj1 = new A();
		var obj2 = new B();
		var obj3 = new C();
		var obj4 = new D();
		obj1.sum(1,2);
		obj2.sum(3,4);
		obj2.diff(4,5);
		obj3.sum(5,6);
		obj3.diff(6,7);
		obj3.multi(7,8);
		obj4.sum(8,9);
		obj4.div(10,2);
	}
}
public class A
{
	public void sum(int a, int b)
	{
		Console.WriteLine(a+b);	
	}
}
public class B : A //single inheritance
{
	public void diff(int a, int b)
	{
		Console.WriteLine(a-b);	
	}
}
public class C : B //multilevel inheritance
{
	public void multi(int a, int b)
	{
		Console.WriteLine(a*b);	
	}
}

public class D : A {// hierarichal
public void div(int a, int b)
	{
		Console.WriteLine(a/b);	
	}	
}