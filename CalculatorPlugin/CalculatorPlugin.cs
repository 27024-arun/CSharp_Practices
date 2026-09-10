using PluginInterface;

namespace CalculatorPlugin
{
    public class CalculatorPlugin : IPlugin
    {
        public string Name => "Calculator";

        public void Execute()
        {
            int num1 = 10;
            int num2 = 20;
            Console.WriteLine($"Addition result of {num1} and {num2} is {num1 + num2}");
        }
    }
}
