namespace DebugProject
{
    internal static class OrderValidator
    {
        public static bool Validate(Order order)
        {
            if(order.Total > 0)
            {
                return true;
            }
            return false;
        }
    }
}
