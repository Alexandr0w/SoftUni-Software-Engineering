namespace AcademicRecordsApp
{
    using Data;

    public class StartUp
    {
        public static void Main()
        {
            using AcademicRecordsDbContext dbContext = new AcademicRecordsDbContext();

            string[] students = dbContext.Students
                .Select(s => s.FullName)
                .ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, students));
        }
    }
}
