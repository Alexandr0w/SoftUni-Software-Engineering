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

            const string outputFilePath = "../../../Results/users-and-products.xml";
            string result = GetUsersWithProducts(dbContext);

            File.WriteAllText(outputFilePath, result, Encoding.Unicode);
            Console.WriteLine(result);
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            UserDto[] users = context.Users
                .Where(u => u.ProductsSold.Count > 0)
                .Select(u => new UserDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new ProductsDto
                    {
                        Count = u.ProductsSold.Count,
                        Products = u.ProductsSold
                            .Select(p => new ProductDto
                            {
                                Name = p.Name,
                                Price = p.Price
                            })
                            .OrderByDescending(p => p.Price)
                            .ToArray()
                    }
                })
                .OrderByDescending(u => u.SoldProducts.Count)
                .ToArray();

            UsersDto usersDto = new UsersDto()
            {
                Count = users.Length,
                Users = users
                    .Take(10)
                    .ToArray()
            };

            string result = XmlHelper.Serialize(usersDto, "Users");
            return result;
        }
    }
}