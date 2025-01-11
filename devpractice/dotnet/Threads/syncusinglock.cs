using System;
using System.Threading;
class Program
{
	private static object obj = new object();
	private static int cnt=0;
	public static void Main()
	{
		var t1= new Thread(increment);
		var t2=new Thread(increment);
		t1.Start();
		t2.Start();
		t1.Join();
		t2.Join();
		Console.WriteLine($"Final Counter Value: {cnt}");
	}
	private static void increment()
	{
		for(int i=0;i<1000;i++)
		{
			lock(obj)
				cnt++;
		}
	}
	
}