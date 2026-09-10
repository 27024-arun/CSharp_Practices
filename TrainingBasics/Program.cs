using System.Diagnostics;

namespace TrainingBasics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            for(int i=0; i < 1000000; i++)
            {
                DivideTry(i);
            }
            watch.Stop();
            Console.WriteLine("Time taken to finish the loop using try: " + watch.ElapsedMilliseconds);
            watch.Restart();
            for (int i = 0; i < 1000000; i++)
            {
                Divide(i);
            }
            Console.WriteLine("Time taken to finish the loop using normal handle: " + watch.ElapsedMilliseconds);
            Console.ReadLine();
        }
        static int DivideTry(int Value)
        {
            try
            {
                return 100 / Value;
            }
            catch
            {
                return 0;
            }
        }
        static int Divide(int Value)
        {
            if (Value > 0)
            {
                return 100 / Value;
            }
            else
            {
                return 0;
            }
        }
    }
}
