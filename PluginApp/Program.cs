using System.Reflection;
using PluginInterface;

namespace PluginApp
{
    internal class Program
    {
        static void Main(string[] args) 
        {
            ReflectionContext reflectionContext;
            string pluginFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Plugins");
            string[] files = Directory.GetFiles(pluginFolder);
            foreach (string dll in files)
            {
                Console.WriteLine($"\nLoading: {Path.GetFileName(dll)}");
                Assembly assembly = Assembly.LoadFrom(dll);
                foreach (Type type in assembly.GetTypes())
                {
                    if (typeof(IPlugin).IsAssignableFrom(type))
                    {
                        Console.WriteLine($"Plugin Found: {type.Name}");
                        IPlugin plugin = (IPlugin)Activator.CreateInstance(type);
                        Console.WriteLine($"Plugin Name: {plugin.Name}");
                        plugin.Execute();
                    }
                }
            }

            Sample s = new Sample();
            object?[]? array = { "Hii" };
            Type type1 = typeof(Sample);
            MethodInfo method = type1.GetMethod("Show", BindingFlags.NonPublic | BindingFlags.Instance);
            object? obj = method.Invoke(s,array);
            Console.WriteLine($"\n{method.Name}");
            Console.WriteLine($"\n{obj}");
            Console.ReadKey();
        }
    }

    public class Sample
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public void Display()
        {
            Console.WriteLine($"I am Peter");
        }

        private string Show(string message)
        {
            return $"{message} Show method";
        }
    }
}