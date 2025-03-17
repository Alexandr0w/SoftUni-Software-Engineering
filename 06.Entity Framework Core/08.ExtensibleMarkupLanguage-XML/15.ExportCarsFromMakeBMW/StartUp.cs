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

            const string outputFilePath = "../../../Results/bmw-cars.xml";
            string result = GetCarsFromMakeBmw(dbContext);

            File.WriteAllText(outputFilePath, result, Encoding.Unicode);
            Console.WriteLine(result);
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            ExportBmwCarsDto[] bmwCars = context.Cars
            .Where(c => c.Make == "BMW")
            .Select(c => new ExportBmwCarsDto()
            {
                Id = c.Id,
                Model = c.Model,
                TraveledDistance = c.TraveledDistance
            })
            .OrderBy(c => c.Model)
            .ThenByDescending(c => c.TraveledDistance)
            .ToArray();

            string result = XmlHelper.Serialize(bmwCars, "cars");
            return result;
        }
    }
}