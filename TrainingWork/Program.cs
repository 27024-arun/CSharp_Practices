using System.Security.Cryptography.X509Certificates;

namespace TrainingWork
{
    public delegate void CalculateEventHandler(params int[] values); //Doesn't hold memory (its a template)
    internal class Program
    {
        public static event CalculateEventHandler CalculateEvent;
        static void Main(string[] args)
        {

            public CustomList<Sample> clist = new CustomList<Sample>();
            ListExtensions ext = new ListExtensions();
            List<int> intlist = [];
            CalculateEvent += Addition;
            CalculateEvent += Mult;

            CalculateEvent(5,6,7);
            Func<int, int, int> addfunc = (x, y) => { return x + y; };
            Action<int> action;
            string email = "arun@gmail.com"
            if (email.IsEmail())
            {
                Console.WriteLine("Valid email");
            }
            Console.ReadLine();
        }
        static void Addition(params int[] values)
        {
            Console.Write("\nAddition result: "+values.Sum());
        }
        static void Mult(params int[] values)
        {
            int mul = 1;
            foreach(int i in values)
            {
                mul = mul * i; ;
            }
            Console.Write("\nMultiplication result: " + mul);
        }
    }
    internal class Sample : IDisposable
    {
        public void dispose()
        {
            
        }
    }
}
