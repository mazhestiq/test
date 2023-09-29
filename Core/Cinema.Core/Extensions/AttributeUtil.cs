using System.Linq.Expressions;
using System.Reflection;

namespace Cinema.Core.Extensions
{
    public static class AttributeUtil
    {
        public static PropertyInfo GetPropertyInfo<T>(Expression<Func<T>> propertyLambda)
        {
            if (!(propertyLambda.Body is MemberExpression member))
            {
                throw new ArgumentException(string.Format("Expression '{0}' doesn't refers to a property.", propertyLambda.ToString()));
            }

            var propInfo = member.Member as PropertyInfo;
            if (propInfo == null)
            {
                throw new ArgumentException(string.Format("Expression '{0}' refers to a field, not a property.", propertyLambda.ToString()));
            }
            return propInfo;
        }


        public static object GetCustomAttribute<T>(Expression<Func<T>> propertyLambda, Type attributeType)
        {
            var info = GetPropertyInfo(propertyLambda);
            return info.GetCustomAttribute(attributeType, true);
        }

        public static object Get<T>(Expression<Func<T>> propertyLambda, Type attributeType, string propertyName)
        {
            var attribute = GetCustomAttribute(propertyLambda, attributeType);
            var info = attributeType.GetProperty(propertyName);
            return info.GetValue(attribute);
        }
    }
}