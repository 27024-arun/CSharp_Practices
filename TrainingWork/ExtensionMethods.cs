namespace TrainingWork
{
    public static class StringEntensions
    {
        public static bool IsNullOrEmpty(this string? value)
        {
            return string.IsNullOrEmpty(value);
        }
        public static bool IsEmail(this string? value)
        {
            if (string.IsNullOrWhiteSpace(value)) return false;
            if(value.Count(i =>  i == '@') != 1) return false;
            return true;
        }
    }
}
