namespace ThreadProcessor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
            ImageProcessor imageProcessor = new ImageProcessor();
            imageProcessor.Start(5);

            while(true)
            {
                ConsoleKey userChoice = Console.ReadKey().Key;
                if(userChoice == ConsoleKey.Spacebar)
                {
                    break;
                }
                else if(userChoice == ConsoleKey.Enter)
                {
                    for(int i = 0; i < 10 ; i++)
                    {
                        Image image = new Image()
                        {
                            id = ++counter,
                        };
                        imageProcessor.Add(image);
                    }
                    Console.WriteLine($"10 Images added for processing");
                }
            }

            Console.WriteLine($"Enter any key to stop.");
            Console.ReadKey();
            imageProcessor.Stop();
            Console.WriteLine($"Threads are terminated");
            Console.ReadKey();
        }
    }
}