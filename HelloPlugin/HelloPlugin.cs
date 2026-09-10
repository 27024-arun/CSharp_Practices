using PluginInterface;

namespace HelloPlugin
{
    public class HelloPlugin : IPlugin
    {
        public string Name => "Hello";

        public void Execute()
        {
            Console.WriteLine("Hello");
        }
    }
}
