using System.Threading.Tasks;

namespace ThreadProcessor
{
    internal class TaskSample
    {
        public async Task Run(Image image)
        {
            await Connect();
            Task<string> taskA =  ReadTableA();
            Task<string> taskB = ReadTableB();
            Task<string> taskC = ReadTableC();
            await Task.WhenAll(taskA, taskB, taskC);
            await Close();
        }

        public async Task Connect()
        {
            Console.WriteLine("Connecting");
            await Task.Delay(3000);
        }

        public async Task<string> ReadTableA()
        {
            Console.WriteLine("Reading table As");
            await Task.Delay(3000);
            return "I am from Table A";
        }
        public async Task<string> ReadTableB()
        {
            Console.WriteLine("Reading table B");
            await Task.Delay(3000);
            return "I am from Table B";
        }
        public async Task<string> ReadTableC()
        {
            Console.WriteLine("Reading table C");
            await Task.Delay(3000);
            return "I am from Table C";
        }
        public async Task Close()
        {
            Console.WriteLine("Closing");
            await Task.Delay(3000);
        }

        private static Image Process(Image image, int threadId)
        {
            Console.WriteLine($"{threadId} : Processing {image.id}");
            image.StartTime = DateTime.Now;
            Thread.Sleep(3000);
            image.EndTime = DateTime.Now;
            Console.WriteLine($"{threadId} : Found image to processed {image.id}");
            return image;
        }
    }
}