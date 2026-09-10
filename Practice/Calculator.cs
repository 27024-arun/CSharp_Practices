namespace Practice
{
    internal class Calculator : ICalculate
    {
        public double Add(double firstNumber, double secondNumber)
        {
            return firstNumber + secondNumber;
        }
        public double Subtract(double firstNumber, double secondNumber)
        {
            return firstNumber - secondNumber;
        }

        public double Divide(double firstNumber, double secondNumber)
        {
            return firstNumber / secondNumber;
        }

        public double Multiple(double firstNumber, double secondNumber)
        {
            return firstNumber * secondNumber;
        }
    }
}
