namespace DebugProject
{
    internal class Program
    {
        private static bool isDiscountApplied = false;
        static void Main(string[] args)
        {
            /*int[] average = new int[20];
            int[] price = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20};
            int[] quantity = { 1, 2, 3, 4, 5, 6, 7, 8, 0, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19};
            for(int i = 1; i <= price.Length; i++)
            {
                average[i] = price[i] / quantity[i];
            }
            ProcessOrder(new Order()
            {
                Total = 50
            });
            Order order = new Order();
            order.Total = 100;
            ApplyDiscount(order);
            ProcessOrder(order);
            */

            Order order = new Order();
            order.Total = 50;
            bool validatorResult = Validator.Validate("value");
            bool orderValidateResult = OrderValidator.Validate(order);
            Console.WriteLine($"String Validator Result: {validatorResult}");
            Console.WriteLine($"Order Validator Result: {orderValidateResult}");
            Console.ReadKey();
        }
        static void ProcessOrder(Order order)
        {
            Console.WriteLine(order.Total);
            Console.WriteLine(isDiscountApplied);
        }
        static void ApplyDiscount(Order order)
        {
            order.Total = order.Total * 0.9;
            isDiscountApplied = true;
        }
    }
    class Order
    {
        public double Total { get; set; }
    }
}
