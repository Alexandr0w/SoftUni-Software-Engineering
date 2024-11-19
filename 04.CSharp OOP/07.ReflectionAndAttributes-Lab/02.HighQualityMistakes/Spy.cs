using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string className, params string[] fieldNames)
        {
            Type? classType = Type.GetType(className);
            FieldInfo[] classFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | 
                BindingFlags.NonPublic | BindingFlags.Public);
            StringBuilder sb = new StringBuilder();

            Object? classInstance = Activator.CreateInstance(classType, new object[] { });

            sb.AppendLine($"Class under investigation: {className}");

            foreach (FieldInfo field in classFields.Where(f => fieldNames.Contains(f.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }

            return sb.ToString().Trim();
        }

        public string AnalyzeAccessModifiers(string className)
        {
            Type? type = Type.GetType(className);
            if (type is null)
            {
                throw new InvalidOperationException("Type not found");
            }

            List<string> lines = new List<string>();
            FieldInfo[] allFields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic
                | BindingFlags.Public);


            foreach (FieldInfo field in allFields.Where(f => !f.IsPrivate))
            {
                lines.Add($"{field.Name} must be private!");
            }

            PropertyInfo[] allProperties = type.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic
                | BindingFlags.Public);

            foreach (PropertyInfo property in allProperties)
            {
                MethodInfo? getMethod = property.GetMethod;
                if (getMethod is not null && !getMethod.IsPublic)
                {
                    lines.Add($"{getMethod.Name} have to be public!");
                }
            }

            foreach (PropertyInfo property in allProperties)
            {
                MethodInfo? SetMethod = property.SetMethod;
                if (SetMethod is not null && !SetMethod.IsPublic)
                {
                    lines.Add($"{SetMethod.Name} have to be private!");
                }
            }

            return string.Join(Environment.NewLine, lines);
        }
    }
}
