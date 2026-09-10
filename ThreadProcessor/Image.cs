namespace ThreadProcessor
{
    internal class Image
    {
        public int id {  get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public long ProcessingTime
        {
            get
            {
                return Convert.ToInt32((EndTime - StartTime).TotalMilliseconds);
            }
        }


    }
}
