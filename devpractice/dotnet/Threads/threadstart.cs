using System;
using System.Threading;

class Program
{
    static void Main()
    {
        // Create a new thread
        Thread thread = new Thread(PrintNumbers);
        thread.Start();  // Start the thread

        // Main thread continues
        for (int i = 1; i <= 5; i++)
        {
            Console.WriteLine($"Main Thread: {i}");
            Thread.Sleep(500);  // Simulate some work
        }

        thread.Join();  // Wait for the new thread to complete
    }

    // Method to be executed by the thread
    static void PrintNumbers()
    {
        for (int i = 1; i <= 5; i++)
        {
            Console.WriteLine($"New Thread: {i}");
            Thread.Sleep(1000);  // Simulate some work
        }
    }
}
