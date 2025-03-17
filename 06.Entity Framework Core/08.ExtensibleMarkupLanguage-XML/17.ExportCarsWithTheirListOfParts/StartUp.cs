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
           

            string result = XmlHelper.Serialize(localSuppliers, "suppliers");
            return result;
        }
    }
}