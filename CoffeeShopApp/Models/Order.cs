namespace CoffeeShopApp.Models
{
    internal class Order
    {
        public Order(int Id, Coffee CoffeeOrdered, int UserId)
        {
            this.OrderId = Id;
            this.CoffeeOrdered = CoffeeOrdered;
            this.UserId = UserId;
        }

        public int OrderId { get; set; }

        public Coffee CoffeeOrdered { get; set; }

        public int UserId { get; set; }
    }
}