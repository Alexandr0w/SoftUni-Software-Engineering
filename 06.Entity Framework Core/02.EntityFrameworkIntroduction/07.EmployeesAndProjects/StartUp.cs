using SoftUni.Data;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        public static void Main()
        {
            SoftUniContext dbContext = new SoftUniContext();
            string result = GetEmployeesInPeriod(dbContext);

            Console.WriteLine(result);
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employeesWithProjects = context.Employees
                .Select(e => new
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    ManagerFirstName = e.Manager == null ? null : e.Manager.FirstName,
                    ManagerLastName = e.Manager == null ? null : e.Manager.LastName,
                    Projects = e.EmployeesProjects
                        .Select(ep => ep.Project)
                        .Where(p => p.StartDate.Year >= 2001 && p.StartDate.Year <= 2003)
                        .Select(p => new
                        {
                            ProjectName = p.Name,
                            p.StartDate,
                            p.EndDate
                        })
                        .ToArray()
                })
                .Take(10)
                .ToArray();

            foreach (var e in employeesWithProjects)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - Manager: {e.ManagerFirstName} {e.ManagerLastName}");

                foreach (var p in e.Projects)
                {
                    string startDate = p.StartDate.ToString("M/d/yyyy h:mm:ss tt");
                    string endDate = p.EndDate == null ? "not finished" : p.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt");
                    sb.AppendLine($"--{p.ProjectName} - {startDate} - {endDate}");
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
