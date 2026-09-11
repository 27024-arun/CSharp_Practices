namespace ThreadProcessor
{
    internal class ImageProcessor
    {
        private AutoResetEvent _threadEvent = new AutoResetEvent(false);

        private List<Image> _images = new List<Image>();

        private List<Thread> _threads = new List<Thread>();

        private int _threadCounter = 0;

        public bool IsRunning { get; private set; }
        
        public bool Start(int threadCount)
        {
            if (IsRunning)
            {
                return true;
            }

            IsRunning = true;
            for (int i = 0; i < threadCount; i++)
            {
                Thread thread = new Thread(Run);
                _threads.Add(thread);
                thread.Start();
            }

            return true;
        }

        public bool Stop()
        {
            IsRunning = false;
            _threads.Clear();
            _threadEvent.Set();
            return true;
        }

        private void Run()
        {
            int threadId = Interlocked.Increment(ref _threadCounter);
            while (IsRunning || _images.Count > 0)
            {
                Image? image = null;
                bool hasImage = false;
                lock (_images)
                {
                    if (_images.Count > 0)
                    {
                        image = _images[0];
                        _images.RemoveAt(0);
                        hasImage = true;
                        Console.WriteLine($"{threadId} : Found image to process {image.id}");
                    }
                    else
                    {
                        hasImage = false;
                    }
                }
                if (!hasImage && IsRunning)
                {
                    Console.WriteLine($"{threadId} : No images found for processing.");
                    _threadEvent.WaitOne();
                    continue;
                }
                if (image != null)
                {
                    Process(image, threadId);
                }
            }
            Console.WriteLine($"{threadId} : Stopped thread");
        }

        public void Add(Image image)
        {
            lock (_images)
            {
                _images.Add(image);
                _threadEvent.Set();
            }
        }
        private static bool Process(Image image, int threadId)
        {
            Console.WriteLine($"{threadId} : Processing {image.id}");
            image.StartTime = DateTime.Now;
            Thread.Sleep(3000);
            image.EndTime = DateTime.Now;
            Console.WriteLine($"{threadId} : Found image to processed {image.id}");
            return true;
        }
    }
}