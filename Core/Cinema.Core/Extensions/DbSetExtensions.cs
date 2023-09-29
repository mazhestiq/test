using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Cinema.Core.Extensions
{
    public static class DbSetExtensions
    {

        public static IQueryable<T> AddIncludes<T>(this IQueryable<T> query, IEnumerable<string> includes) where T : class
        {
            return includes == null ? query : includes.Aggregate(query, (current, include) => current.Include(include));
        }

        public static IQueryable<T> AddIncludes<T>(this IQueryable<T> query, params Expression<Func<T, object>>[] includes) where T : class
        {
            return includes == null ? query : includes.Aggregate(query, (current, include) => current.Include(include));
        }


        public static void ExcludeDbGeneratedForUpdate(this EntityEntry entry)
        {
            foreach (var property in entry.CurrentValues.Properties)
            {
                if (property.PropertyInfo != null && Attribute.IsDefined(property.PropertyInfo, typeof(DatabaseGeneratedAttribute)))
                    entry.Property(property.Name).IsModified = false;
            }
        }
    }
}