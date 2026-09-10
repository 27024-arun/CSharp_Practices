using System.Security.Cryptography;

namespace DebuggingPractice
{
    internal class Program
    {
        public static int num = 0;
        public static void Main()
        {
            //ConsoleOperator operate = new ConsoleOperator();
            /*for (int i=1 ; i<=10; i++)
            {
                //string num = Console.ReadLine();
                //Console.WriteLine(num);
                Increment();
                Console.WriteLine(num);
            }
            //operate.PeformCalculation();
            operate.DisplayUserData();
            */
            Thread T1 = new Thread(Increment);
            Thread T2 = new Thread(Increment);
            T1.Start();
            T2.Start();
            Console.ReadKey();
        }
        public static void Increment()
        {
            for( int i=0; i < 100;i++)
            {
                num++;
            }
        }
    }
}
