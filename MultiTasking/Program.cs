using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Main thread starting.");

        BlockingCode(); // Blocking Code
        //await BlockingTask(); // Blocking Task
        //Task.Run(() => NonBlockingTask()); // NonBlocking Task

        Console.WriteLine("Main thread ending.");
        Thread.Sleep(10000);
    }

    static void BlockingCode()
    {
        Console.WriteLine($"Blocking code {Environment.NewLine}");
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine($"Long-running operation: {i + 1}");
            Thread.Sleep(1000); // Simulate work
        }
    }

    static async Task BlockingTask()
    {
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine($"Long-running operation: {i + 1}");
            await Task.Delay(1000); // Simulate work
        }
    }

    static async Task NonBlockingTask()
    {
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine($"Long-running operation: {i + 1}");
            await Task.Delay(1000); // Simulate work
        }
    }
}