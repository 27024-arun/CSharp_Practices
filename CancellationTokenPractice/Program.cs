class Program
{
    static async Task Main()
    {
        using var cts = new CancellationTokenSource();

        // Start a task that can be cancelled
        Task worker = DoWorkAsync(cts.Token);

        Console.WriteLine("Press any key to cancel...");
        Console.Write($"Do you want to cancel the task (Y/N): ");
        ConsoleKey userChoice = Console.ReadKey().Key;

        // Request cancellation
        if (userChoice is ConsoleKey.Y)
        {
            cts.Cancel();
        }

        try
        {
            await worker; // Wait for task to finish
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("\nTask was cancelled.");
        }

        Console.WriteLine("Program finished.");
        Console.ReadKey();
    }

    static async Task DoWorkAsync(CancellationToken token)
    {
        for (int i = 1; i <= 10; i++)
        {
            // Check for cancellation request
            token.ThrowIfCancellationRequested();

            Console.WriteLine($"Working... step {i}");
            await Task.Delay(500, token); // Pass token to delay for cooperative cancellation
        }

        Console.WriteLine("Work completed successfully.");
    }
}
