using CarDealer.Data;
using CarDealer.DTOs.Export;
using CarDealer.Utilities;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            using CarDealerContext dbContext = new CarDealerContext();
            dbContext.Database.Migrate();

            Console.WriteLine("Database migrated to the latest version successfully!");

            const string outputFilePath = "../../../Results/customers-total-sales.xml";
            string result = GetTotalSalesByCustomer(dbContext);

            File.WriteAllText(outputFilePath, result, Encoding.Unicode);
            Console.WriteLine(result);
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customerSales = context.Customers
            .Where(c => c.Sales.Any())
            .Select(c => new
            {
                fullName = c.Name,
                boughtCars = c.Sales.Count(),
                moneyCars = c.IsYoungDriver
                    ? c.Sales.SelectMany(s => s.Car.PartsCars.Select(p => Math.Round(p.Part.Price * 0.95m, 2)))
                    : c.Sales.SelectMany(s => s.Car.PartsCars.Select(p => Math.Round(p.Part.Price, 2)))
            })
            .ToArray();

            ExportTotalSalesByCustomerDto[] output = customerSales
                .Select(o => new ExportTotalSalesByCustomerDto
                {
                    FullName = o.fullName,
                    BoughtCars = o.boughtCars,
                    SpentMoney = o.moneyCars.Sum()
                })
                .OrderByDescending(o => o.SpentMoney)
                .ToArray();

            string result = XmlHelper.Serialize(output, "customers");
            return result;
        }
    }
}