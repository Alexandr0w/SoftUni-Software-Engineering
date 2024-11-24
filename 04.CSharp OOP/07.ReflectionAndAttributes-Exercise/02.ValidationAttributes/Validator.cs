using System.Reflection;
using ValidationAttributes.Attributes;

namespace ValidationAttributes
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            Type type = obj.GetType();

            PropertyInfo[] properties = type.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                var attributes = property.GetCustomAttributes<MyValidationAttribute>().ToArray();

                if (attributes.Length == 0) continue;

                object propertyValue = property.GetValue(obj);
                if (attributes.Any(a => !a.IsValid(propertyValue))) return false;
            }

            return true;
        }
    }
}
