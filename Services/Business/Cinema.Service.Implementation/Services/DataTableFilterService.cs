using System.ComponentModel;
using Cinema.Domains.Enums;
using Cinema.Domains.Models;
using Cinema.Service.Contracts.Services;

namespace Cinema.Service.Implementation.Services
{
    public class DataTableFilterService : IDataTableFilterService
    {
        public async Task<Dictionary<string, List<LookUpModel>>> GetEntities(IServiceProvider serviceProvider, string[] entities)
        {
            var result = new Dictionary<string, List<LookUpModel>>();
            foreach (var key in entities.Distinct())
            {
                if (result.ContainsKey(key.ToLower()))
                {
                    continue;
                }

                var value = DictionaryResolver.GetValueOrDefault(key.ToLower());
                if (value == null)
                    continue;

                var dataItem = await value(serviceProvider);
                result.Add(key.ToLower(), dataItem);
            }

            return result;
        }

        private static readonly Dictionary<string, Func<IServiceProvider, Task<List<LookUpModel>>>> DictionaryResolver =
            new(StringComparer.InvariantCultureIgnoreCase)
            {
                {
                    nameof(GenreType).ToLower(),
                    _ =>
                    {
                        return Task.FromResult(GetValues<GenreType>().Select(n => n.Value).ToList());
                    }
                }
            };



        static readonly System.Collections.Concurrent.ConcurrentDictionary<string, Dictionary<Enum, LookUpModel>> CachedValues = new();

        private static Dictionary<Enum, LookUpModel> GetValues<T>()
        {
            var type = typeof(T);
            return CachedValues.GetOrAdd(type.FullName, _ =>
            {
                var dict = new Dictionary<Enum, LookUpModel>();
                foreach (Enum item in Enum.GetValues(type))
                {
                    var value = StringValueOfEnum(item);
                    dict.Add(item, new LookUpModel()
                    {
                        Id = Convert.ToInt32(item).ToString(),
                        Item = value
                    });
                }
                return dict;
            });
        }

        static string StringValueOfEnum(Enum value)
        {
            var fi = value.GetType().GetField(value.ToString());
            var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            var result = (attributes.Length > 0) ? attributes[0].Description : value.ToString();
            return result;
        }
    }
}