namespace ProductShop
{
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using ProductShopContext dbContext = new ProductShopContext();

            dbContext.Database.Migrate();
            Console.WriteLine("Database migrated successfully!");

            const string outputFilePath = "../../../Results/output.json";
            string result = GetCategoriesByProductsCount(dbContext);

            File.WriteAllText(outputFilePath, result, Encoding.Unicode);
            Console.WriteLine(result);
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categoriesByProductCount = context.Categories
                .OrderByDescending(c => c.CategoriesProducts.Count)
                .Select(c => new
                {
                    category = c.Name,
                    productsCount = c.CategoriesProducts.Count,
                    averagePrice = $"{c.CategoriesProducts.Average(cp => cp.Product.Price):F2}",
                    totalRevenue = $"{c.CategoriesProducts.Sum(cp => cp.Product.Price):F2}"
                });

            string jsonResult = JsonConvert.SerializeObject(categoriesByProductCount, Formatting.Indented);

            return jsonResult;
        }
    }
}