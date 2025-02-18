using SoftUni.Data;

namespace SoftUni
{ 
    public class StartUp
    {
        public static void Main()
        {
            SoftUniContext dbContext = new SoftUniContext();
            string result = DeleteProjectById(dbContext);

            Console.WriteLine(result);
        }

        public static string DeleteProjectById(SoftUniContext context)
        {
            const int deleteProjectId = 2;

            var employeeProjectsDelete = context.EmployeesProjects
                .Where(ep => ep.ProjectId == deleteProjectId)
                .ToList();

            context.EmployeesProjects.RemoveRange(employeeProjectsDelete);

            var deleteProject = context.Projects.Find(deleteProjectId);

            if (deleteProject != null)
            {
                context.Projects.Remove(deleteProject);
            }

            context.SaveChanges();

            string[] projectNames = context.Projects
                .Select(p => p.Name)
                .Take(10)
                .ToArray();

            return string.Join(Environment.NewLine, projectNames);
        }
    }
}
