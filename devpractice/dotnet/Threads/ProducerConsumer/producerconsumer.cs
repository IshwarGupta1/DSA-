using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ProducerConsumer
{
    public class producerconsumer
    {
        private static SemaphoreSlim emptySlots;
        private static SemaphoreSlim fullSlots;
        private static SemaphoreSlim mutex;
        private static Queue<int> buffer = new Queue<int>();
        private static int bufferSize = 5;

        // Producer method
        private static async Task Produce(int itemId)
        {
            await emptySlots.WaitAsync(); // Waiting for empty slot
            await mutex.WaitAsync(); // Acquire mutex for exclusive access

            buffer.Enqueue(itemId); // Produce an item
            Console.WriteLine($"Produced item {itemId}");

            fullSlots.Release(); // Signal that there is one more item to consume
            mutex.Release(); // Release the mutex
        }

        // Consumer method
        private static async Task Consume()
        {
            await fullSlots.WaitAsync(); // Waiting for filled slot
            await mutex.WaitAsync(); // Acquire mutex

            int itemId = buffer.Dequeue(); // Consume an item
            Console.WriteLine($"Consumed item {itemId}");

            emptySlots.Release(); // Signal that there is one more empty slot available
            mutex.Release(); // Release the mutex
        }

        public static async Task ProduceNConsume()
        {
            emptySlots = new SemaphoreSlim(bufferSize); // 5 empty slots for the buffer
            fullSlots = new SemaphoreSlim(0); // Initially no items to consume
            mutex = new SemaphoreSlim(1); // Allow exclusive access to buffer

            var tasks = new List<Task>();

            // Add both producer and consumer tasks to run concurrently
            for (int i = 0; i < 10; i++) // 10 producer tasks
            {
                tasks.Add(Produce(i));
            }

            for (int i = 0; i < 5; i++) // 5 consumer tasks
            {
                tasks.Add(Consume());
            }

            // Wait for all tasks to complete
            await Task.WhenAll(tasks);
        }
    }
}
