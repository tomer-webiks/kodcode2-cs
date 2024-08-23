using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Main thread starting.");

        //BlockingCode(); // Blocking Code
        //BlockingCode(); // Blocking Code
        //BlockingTask(); // Blocking Task
        //BlockingTask(); // Blocking Task

        //Task.Run(() => BlockingCode()); // NonBlocking Task
        //Task.Run(() => BlockingCode()); // NonBlocking Task
        NonBlockingTask();
        NonBlockingTask();

        Console.WriteLine("Main thread ending.");
        Thread.Sleep(20000);
    }
    
    static async Task BlockingCode()
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

    static async void NonBlockingTask()
    {
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine($"Long-running operation: {i + 1}");
            await Task.Delay(2000); // Simulate work
            Console.WriteLine("After wait period.");
        }
    }
}