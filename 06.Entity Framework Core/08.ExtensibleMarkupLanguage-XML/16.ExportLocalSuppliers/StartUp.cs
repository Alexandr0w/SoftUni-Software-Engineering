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

            const string outputFilePath = "../../../Results/local-suppliers.xml";
            string result = GetLocalSuppliers(dbContext);

            File.WriteAllText(outputFilePath, result, Encoding.Unicode);
            Console.WriteLine(result);
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            ExportLocalSuppliersDto[] localSuppliers = context.Suppliers
            .Where(s => !s.IsImporter)
            .Select(s => new ExportLocalSuppliersDto()
            {
                Id = s.Id,
                Name = s.Name,
                PartsCount = s.Parts.Count
            })
            .ToArray();

            string result = XmlHelper.Serialize(localSuppliers, "suppliers");
            return result;
        }
    }
}