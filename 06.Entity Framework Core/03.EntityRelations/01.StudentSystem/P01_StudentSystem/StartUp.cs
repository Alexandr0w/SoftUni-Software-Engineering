namespace P01_StudentSystem
{
    using Data;

    public class StartUp
    {
        public static void Main()
        {
            Console.WriteLine("Db Creation Started...");

            try
            {
                using StudentSystemContext dbContext = new StudentSystemContext();

                dbContext.Database.EnsureDeleted();
                dbContext.Database.EnsureCreated();

                Console.WriteLine("Db Creation was successful!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Db Creation failed!");
                Console.WriteLine(e.Message);
            }
        }
    }
}
