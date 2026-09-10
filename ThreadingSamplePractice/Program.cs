namespace ThreadingSamplePractice
{
    internal class Program
    {
        public volatile bool IsRunning = false;
        static void Main(string[] args)
        {
            Thread t1 = Thread.CurrentThread;
            t1.Start();
        }
    }
}
