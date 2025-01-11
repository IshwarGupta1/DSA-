using System;
using System.Threading;

class Program
{
    static void Main()
    {
        // Create a new thread
        Thread thread = new Thread(PrintNumbers);
        thread.Start(2);  // Start the thread

        // Main thread continues
        for (int i = 1; i <= 5; i++)
        {
            Console.WriteLine($"Main Thread: {i}");
            Thread.Sleep(500);  

        thread.Join();
    }

    // Method to be executed by the thread
    static void PrintNumbers(object obj)
    {
		int a = (int)obj;
        for (int i = 1; i <= 5; i++)
        {
            Console.WriteLine($"New Thread: {a+i} ");
            Thread.Sleep(1000);
        }
    }
	}
}
