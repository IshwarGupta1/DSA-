using System;
using System.Threading;
class Program
{
	private static Semaphore obj = new Semaphore(1,1);
	private static int cnt=0;
	public static void Main()
	{
		ThreadPool.QueueUserWorkItem(new WaitCallback(increment));
		ThreadPool.QueueUserWorkItem(new WaitCallback(increment));
		Thread.Sleep(1000);
		Console.WriteLine($"Final Counter Value: {cnt}");
	}
	private static void increment(object state)
	{
		for(int i=0;i<1000;i++)
		{
			obj.WaitOne();
				cnt++;
			obj.Release();
		}
	}
	
}