namespace CoffeeShopApp.Models
{
    internal class Order
    {
        public Order()
        {
        }

        public Order(int Id, Coffee CoffeeOrdered)
        {
            this.Id = Id;
            this.CoffeeOrdered = CoffeeOrdered;
        }

        public int Id { get; set; }

        public Coffee CoffeeOrdered { get; set; }
    }
}