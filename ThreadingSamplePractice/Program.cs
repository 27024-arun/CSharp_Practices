namespace ThreadingSamplePractice
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}-Main method started");
            await DisplayName();
            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}-Name is displayed");
            await DisplayAge();
            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}-Age is displayed");
            await DisplayPlace();
            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}-Place is displayed");
            Console.ReadKey();
        }
        static async Task DisplayName()
        {
            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}-Before delay in name display");
            await Task.Delay(1000);
            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}-After delay in name display");
            Console.WriteLine($"Arun");
        }
        static async Task DisplayAge()
        {
            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}-Before delay in age display");
            await Task.Delay(1000);
            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}-After delay in age display");
            Console.WriteLine($"20");
        }
        static async Task DisplayPlace()
        {
            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}-Before delay in place display");
            await Task.Delay(1000);
            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}-After delay in place display");
            Console.WriteLine("CBE");
        }
    }
}
