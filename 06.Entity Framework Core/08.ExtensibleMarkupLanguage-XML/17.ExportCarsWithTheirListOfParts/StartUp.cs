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

            const string outputFilePath = "../../../Results/cars-and-parts.xml";
            string result = GetCarsWithTheirListOfParts(dbContext);

            File.WriteAllText(outputFilePath, result, Encoding.Unicode);
            Console.WriteLine(result);
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            ExportCarsWithPartsDto[] carsWithPartsDtos = context.Cars
                .OrderByDescending(c => c.TraveledDistance)
                .ThenBy(c => c.Model)
                .Select(c => new ExportCarsWithPartsDto
                { 
                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance.ToString(),
                    Parts = c.PartsCars
                        .Select(pc => pc.Part)
                        .OrderByDescending(p => p.Price)
                        .Select(p => new ExportCarsWithPartsPartDto
                        {
                            Name = p.Name,
                            Price = p.Price.ToString()
                        })
                        .ToArray()
                })
                .Take(5)
                .ToArray();

            string result = XmlHelper.Serialize(carsWithPartsDtos, "cars");
            return result;
        }
    }
}