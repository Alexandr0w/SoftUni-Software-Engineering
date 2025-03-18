using ProductShop.Data;
using ProductShop.DTOs.Import;
using ProductShop.Models;
using ProductShop.Utilities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ProductShop.DTOs.Export;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            using ProductShopContext dbContext = new ProductShopContext();
            dbContext.Database.Migrate();

            Console.WriteLine("Database migrated to the latest version successfully!");

            const string outputFilePath = "../../../Results/users-sold-products.xml";
            string result = GetSoldProducts(dbContext);

            File.WriteAllText(outputFilePath, result, Encoding.Unicode);
            Console.WriteLine(result);
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            ExportUsersDto[] users = context.Users
                .Where(u => u.ProductsSold.Count > 0)
                .Select(u => new ExportUsersDto()
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold
                    .Select(p => new ExportProductsDto()
                    {
                        Name = p.Name,
                        Price = p.Price,
                    })
                    .ToArray()
                })
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Take(5)
                .ToArray();

            string result = XmlHelper.Serialize(users, "Users");
            return result;
        }
    }
}