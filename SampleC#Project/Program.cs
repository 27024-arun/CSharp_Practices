using CalcLibrary;
namespace SampleC_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Value 1 for calculation:");
            int value1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Value 2 for calculation:");
            int value2 = int.Parse(Console.ReadLine());
            int add =  AddCalculator.add(value1, value2);
            Console.WriteLine("Addition result: "+add);
            int sub = SubCalculator.sub(value1, value2);
            Console.WriteLine("Subtraction result: "+sub);
            int mul = MulCalculator.mul(value1, value2);
            Console.WriteLine("Multiplication result: "+mul);
            int div = DivCalculator.div(value1, value2);
            Console.WriteLine("Division result: "+div);
            Console.ReadLine();
        }
    }
}
