namespace ThreadingSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ThreadTest test = new ThreadTest();
            test.Start();
            Thread.Sleep(1000);
            test.PrintThreadState();
            Console.WriteLine("Enter a key to stop the thread");
            Console.ReadKey();
            test.Stop();
            Console.WriteLine("Thread got stopped");
            test.PrintThreadState();
        }
    }
}