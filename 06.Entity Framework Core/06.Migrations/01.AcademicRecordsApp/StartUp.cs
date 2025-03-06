namespace AcademicRecordsApp
{
    using Data;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Z.EntityFramework.Plus;

    public class StartUp
    {
        public static void Main()
        {
            using AcademicRecordsDbContext dbContext = new AcademicRecordsDbContext();

            // Every time the app is started, the DB will be migrated to the latest migration available
            // This is not suitable for PRODUCTION!!! Only development purposes
            // For PRODUCTION, use Migration Bundles -> easier CI/CD integration
            dbContext.Database.Migrate();

            //FillAllExamsWithDefaultCourse(dbContext);
            //Console.WriteLine("All exams have a course!");
        }

        private static void FillAllExamsWithDefaultCourse(AcademicRecordsDbContext dbContext)
        {
            Course testCourse = new Course
            {
                Name = "Default Course"
            };

            dbContext.Courses.Add(testCourse);
            dbContext.SaveChanges();

            dbContext.Exams
#pragma warning disable CS0472
                .Where(e => e.CourseId == null)
#pragma warning restore CS0472
                .Update(e => new Exam()
                {
                    Course = testCourse
                });

            dbContext.SaveChanges();
        }
    }
}
