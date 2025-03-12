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
            string result = GetSoldProducts(dbContext);

            File.WriteAllText(outputFilePath, result, Encoding.Unicode);
            Console.WriteLine(result);
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var usersWithSoldProducts = context.Users
                .Where(u => u.ProductsSold.Any(p => p.BuyerId.HasValue))
                .Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    SoldProducts = u.ProductsSold
                        .Where(p => p.BuyerId.HasValue)
                        .Select(p => new
                        {
                            p.Name,
                            p.Price,
                            BuyerFirstName = p.Buyer!.FirstName,
                            BuyerLastName = p.Buyer.LastName
                        })
                        .ToArray()
                })
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .ToArray();

            DefaultContractResolver camelCaseResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            string jsonResult = JsonConvert.SerializeObject(usersWithSoldProducts, Formatting.Indented, new JsonSerializerSettings()
            {
                ContractResolver = camelCaseResolver
            });

            return jsonResult;
        }
    }
}