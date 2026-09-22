namespace CoffeeShopApp.Models
{
    internal class Machine
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public bool IsAvailable { get; set; }
    }
}