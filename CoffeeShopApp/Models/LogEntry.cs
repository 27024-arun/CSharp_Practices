namespace CoffeeShopApp.Models
{
    internal class LogEntry
    {
        public LogEntry()
        {
        }

        public LogEntry(string Action, DateTime? Timestamp, string Message, int OrderId, int MachineId)
        {
            this.Action = Action;
            this.Timestamp = Timestamp;
            this.Message = Message;
            this.OrderId = OrderId;
            this.MachineId = MachineId;
        }

        public string Action { get; set; }

        public DateTime? Timestamp { get; set; } = DateTime.Now;

        public string Message { get; set; }

        public int OrderId { get; set; }

        public int MachineId { get; set; }
    }
}
