using SoftUni.Data;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        public static void Main()
        {
            SoftUniContext dbContext = new SoftUniContext();
            string result = GetAddressesByTown(dbContext);

            Console.WriteLine(result);
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var addresses = context.Addresses
                .Select(a => new
                {
                    a.AddressText,
                    a.Town!.Name,
                    a.Employees.Count
                })
                .OrderByDescending(a => a.Count)
                .ThenBy(a => a.Name)
                .ThenBy(a => a.AddressText)
                .Take(10)
                .ToArray();

            foreach (var address in addresses)
            {
                sb.AppendLine($"{address.AddressText}, {address.Name} - {address.Count} employees");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
