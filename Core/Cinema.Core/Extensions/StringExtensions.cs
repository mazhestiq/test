namespace Cinema.Core.Extensions
{
    public static class StringExtensions
    {
        public static bool IsEmptyString(this string value) => string.IsNullOrWhiteSpace(value);
        
    }
}