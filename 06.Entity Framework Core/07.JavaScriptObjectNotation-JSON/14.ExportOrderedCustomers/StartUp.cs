namespace CarDealer
{
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using System.Globalization;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using CarDealerContext dbContext = new CarDealerContext();

            dbContext.Database.Migrate();
            Console.WriteLine("Database migrated successfully!");

            const string outputFilePath = "../../../Results/ordered-customers.json";
            string result = GetOrderedCustomers(dbContext);

            File.WriteAllText(outputFilePath, result, Encoding.Unicode);
            Console.WriteLine(result);
        }

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .Select(c => new
                {
                    c.Name,
                    BirthDate = c.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    c.IsYoungDriver
                })
                .ToArray();

            string customersJson = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return customersJson;
        }
    }
}