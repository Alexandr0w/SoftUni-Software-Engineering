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

            const string outputFilePath = "../../../Results/sales-discounts.xml";
            string result = GetSalesWithAppliedDiscount(dbContext);

            File.WriteAllText(outputFilePath, result, Encoding.Unicode);
            Console.WriteLine(result);
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            ExportSalesWithAppliedDiscountDto[] salesWithDiscount = context
                .Sales
                .Select(s => new ExportSalesWithAppliedDiscountDto()
                {
                    SingleCar = new SingleCar()
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TraveledDistance = s.Car.TraveledDistance
                    },
                    Discount = (int)s.Discount,
                    CustomerName = s.Customer.Name,
                    Price = s.Car.PartsCars.Sum(p => p.Part.Price),
                    PriceWithDiscount = Math.Round((double)(s.Car.PartsCars.Sum(p => p.Part.Price) * (1 - (s.Discount / 100))), 4)
                })
                .ToArray();

            string result = XmlHelper.Serialize(salesWithDiscount, "sales");
            return result;
        }

    }
}