using SoftUni.Data;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        public static void Main()
        {
            SoftUniContext dbContext = new SoftUniContext();
            string result = IncreaseSalaries(dbContext);

            Console.WriteLine(result);
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            List<string> departments = new List<string>() { "Engineering", "Tool Design", "Marketing", "Information Services" };

            var employees = context.Employees
                .Where(e => departments.Any(d => d == e.Department.Name))
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName);

            foreach (var employee in employees)
            {
                employee.Salary *= 1.12M;
            }

            context.SaveChanges();

            StringBuilder sb = new StringBuilder();

            foreach (var e in employees.ToList())
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} (${e.Salary:F2})");
            }

            return sb.ToString().Trim();
        }
    }
}
