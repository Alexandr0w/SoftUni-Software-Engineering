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

            const string outputFilePath = "../../../Results/cars.xml";
            string result = GetCarsWithDistance(dbContext);

            File.WriteAllText(outputFilePath, result, Encoding.Unicode);
            Console.WriteLine(result);
        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            ExportCarsOverDistanceDto[] cars = context.Cars
                .Where(c => c.TraveledDistance > 2_000_000)
                .Select(c => new ExportCarsOverDistanceDto()
                {
                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance.ToString()
                })
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .ToArray();

            string result = XmlHelper.Serialize(cars, "cars");
            return result;
        }
    }
}