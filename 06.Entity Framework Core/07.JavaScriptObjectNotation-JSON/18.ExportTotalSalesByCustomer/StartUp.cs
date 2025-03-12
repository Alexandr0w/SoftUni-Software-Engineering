namespace CarDealer
{
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using CarDealerContext dbContext = new CarDealerContext();

            dbContext.Database.Migrate();
            Console.WriteLine("Database migrated successfully!");

            const string outputFilePath = "../../../Results/customers-total-sales.json";
            string result = GetTotalSalesByCustomer(dbContext);

            File.WriteAllText(outputFilePath, result, Encoding.Unicode);
            Console.WriteLine(result);
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
            .Where(cus => cus.Sales.Any())
            .Select(cus => new
            {
                fullName = cus.Name,
                boughtCars = cus.Sales.Count(),
                moneyCars = cus.Sales
                    .SelectMany(c => c.Car.PartsCars.Select(p => p.Part.Price))
            })
            .AsNoTracking()
            .ToArray();

            var result = customers
                .Select(c => new
                {
                    c.fullName,
                    c.boughtCars,
                    spentMoney = c.moneyCars.Sum()
                })
                .OrderByDescending(c => c.spentMoney)
                .ThenByDescending(c => c.boughtCars)
                .ToArray();

            string customersJson = JsonConvert.SerializeObject(result, Formatting.Indented);

            return customersJson; 
        }
    }
}