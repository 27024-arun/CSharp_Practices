namespace CoffeeShopApp.Models
{
    internal class Coffee
    {
        public Coffee(CoffeeMenuOption Name, TimeSpan SourcingTime, TimeSpan PreparationTime)
        {
            this.Name = Name;
            this.SourcingTime = SourcingTime;
            this.PreparationTime = PreparationTime;
        }

        public CoffeeMenuOption Name { get; set; }

        public TimeSpan SourcingTime { get; set; }

        public TimeSpan PreparationTime { get; set; }
    }
}