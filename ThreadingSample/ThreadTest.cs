namespace ThreadingSample
{
    internal class ThreadTest
    {
        private readonly List<int> _integerList = new List<int>();

        private static bool isRunning = false;

        Thread t1;
        Thread t2;

        public void Start()
        {
            t1 = new Thread(Run);
            t2 = new Thread(Run);
            isRunning = true;
            t1.Start();
            t2.Start();
        }

        public void Stop()
        {
            isRunning = false;
        }

        private void Run()
        {
            Guid threadInfo = Guid.NewGuid();
            Console.WriteLine($"{threadInfo} : Starting Thread");
            while (isRunning)
            {
                Thread.Sleep(1000);
                Console.WriteLine($"{threadInfo} : {DateTime.Now.ToString()}");
            }
            Console.WriteLine($"{threadInfo} : Ending Thread");
        }

        public void PrintThreadState()
        {
            Console.WriteLine($"Thread T1 : {t1.ThreadState}");
            Console.WriteLine($"Thread T2 : {t2.ThreadState}");
        }
    }
}
