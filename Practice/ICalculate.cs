using System.Transactions;

namespace Practice
{
    internal interface ICalculate
    {
        public double Add(double firstNumber, double secondNumber);

        public double Subtract(double firstNumber, double secondNumber);

        public double Multiple(double firstNumber, double secondNumber);

        public double Divide(double firstNumber, double secondNumber);
    }
}
