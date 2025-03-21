using P01_HospitalDatabase.Data;

namespace P01_HospitalDatabase
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Db Creation Started...");

            try
            {
                using HospitalContext dbContext = new HospitalContext();

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
