namespace ProductShop
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using Microsoft.EntityFrameworkCore;

    using Data;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using ProductShopContext dbContext = new ProductShopContext();

            dbContext.Database.Migrate();
            Console.WriteLine("Database migrated successfully!");

            const string outputFilePath = "../../../Results/output.json";
            string result = GetUsersWithProducts(dbContext);

            File.WriteAllText(outputFilePath, result, Encoding.Unicode);
            Console.WriteLine(result);
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var usersWithSoldProducts = context
                .Users
                .Where(u => u.ProductsSold.Any(p => p.BuyerId.HasValue))
                .Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    u.Age,
                    SoldProducts = new
                    {
                        Count = u.ProductsSold
                            .Count(p => p.BuyerId.HasValue),
                        Products = u.ProductsSold
                            .Where(p => p.BuyerId.HasValue)
                            .Select(p => new
                            {
                                p.Name,
                                p.Price
                            })
                            .ToArray()
                    }
                })
                .ToArray()
                .OrderByDescending(u => u.SoldProducts.Count)
                .ToArray();

            var usersDto = new
            {
                UsersCount = usersWithSoldProducts.Length,
                Users = usersWithSoldProducts
            };

            DefaultContractResolver camelCaseResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };
            string jsonResult = JsonConvert.SerializeObject(usersDto, Formatting.Indented, new JsonSerializerSettings()
            {
                ContractResolver = camelCaseResolver,
                NullValueHandling = NullValueHandling.Ignore
            });

            return jsonResult;
        }
    }
}