using Microsoft.EntityFrameworkCore;

namespace Cinema.Core.Extensions
{
    public static class EnumerableExtensions
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
        {
            return enumerable == null || !enumerable.Any();
        }
    }
}