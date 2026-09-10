namespace CarWashSystem.View
{
    public class ViewHelper
    {
        public static void WriteColored(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static string? GetStringData(string message)
        {
            int tries = 3;
            string? userData;
            for (int i = 0; i < tries; i++)
            {
                Console.Write($"{message}: ");
                userData = Console.ReadLine();
                if (!string.IsNullOrEmpty(userData) && !string.IsNullOrWhiteSpace(message))
                {
                    return userData;
                }
                else
                {
                    WriteColored($"Enter a Valid data\n{tries - i - 1} tries left", ConsoleColor.Red);
                }
            }

            return null;
        }

        public static int GetIntData(string message)
        {
            int tries = 3;
            int userData;
            for (int i = 0; i < tries; i++)
            {
                Console.Write($"{message}: ");
                int.TryParse(Console.ReadLine(), out userData);
                if (userData != 0)
                {
                    return userData;
                }
                else
                {
                    WriteColored($"Enter a Valid data\n{tries - i - 1} tries left", ConsoleColor.Red);
                }
            }

            return 0;
        }
    }
}
