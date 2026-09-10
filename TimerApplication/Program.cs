using System.Timers;

namespace TimerApplication
{
    internal class Program
    {
        private static int freeslot = 3;

        public static void Main(string[] args)
        {
            System.Timers.Timer t = new System.Timers.Timer();
            t.Elapsed += CarWash;
            t.Interval = 1000;
            t.Start();
            freeslot--;
            Console.WriteLine(freeslot);
            Console.ReadKey();
            t.Stop();
        }

        private static void CarWash(object? sender, ElapsedEventArgs e)
        {
            Console.Clear();
            Console.WriteLine(DateTime.Now.ToString("hh-mm-ss"));
        }
    }
}