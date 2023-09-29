using System.ComponentModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Cinema.Core.ModelBinders
{
    /// <summary>
    /// Converter to parse Enum not only by int and string value but by Description value
    /// </summary>
    public class CustomEnumConverter : StringEnumConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.String)
            {
                var underlyingType = Nullable.GetUnderlyingType(objectType);
                var enumType = underlyingType ?? objectType;
                var names = Enum.GetNames(enumType);
                foreach (var name in names)
                {
                    var field = enumType.GetField(name);
                    var fds = field.GetCustomAttributes(typeof(DescriptionAttribute), true);
                    foreach (DescriptionAttribute fd in fds)
                    {
                        if (fd.Description == (string)reader.Value)
                            return Enum.Parse(enumType, name);
                    }
                }
            }
            return base.ReadJson(reader, objectType, existingValue, serializer);
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
            {
                writer.WriteNull();
                return;
            }

            if (int.TryParse(value.ToString(), out var enumInt))
            {
                writer.WriteValue(enumInt.ToString());
            }
            else
            {
                try
                {
                    writer.WriteValue($"{(int)value}");
                }
                catch
                {
                    writer.WriteValue(value);
                }
                
            }
        }
    }
}
