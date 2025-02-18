using Microsoft.EntityFrameworkCore;
using SoftUni.Data;

namespace SoftUni
{
    public class StartUp
    {
        public static void Main()
        {
            SoftUniContext dbContext = new SoftUniContext();
            dbContext.Database.EnsureCreated();

            string result = RemoveTown(dbContext);

            Console.WriteLine(result);
        }

        public static string RemoveTown(SoftUniContext context)
        {
            var town = context.Towns
                .Include(t => t.Addresses)
                .FirstOrDefault(t => t.Name == "Seattle");

            context.Addresses.RemoveRange(town!.Addresses);
            context.Towns.Remove(town);

            var employees = context.Employees
                .Where(e => e.Address!.Town!.Name == "Seattle");

            foreach (var e in employees)
            {
                e.AddressId = null;
            }

            context.SaveChanges();

            return $"{town.Addresses.Count} addresses in Seattle were deleted";
        }
    }
}
