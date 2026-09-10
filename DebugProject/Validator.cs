namespace DebugProject
{
    internal static class Validator
    {
        public static bool Validate(string input)
        {
            if(string.IsNullOrEmpty(input))
            {
                return false;
            }
            return true;
        }
    }
}
