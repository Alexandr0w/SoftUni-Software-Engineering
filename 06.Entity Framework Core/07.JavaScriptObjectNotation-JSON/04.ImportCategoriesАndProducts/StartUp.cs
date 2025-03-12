namespace ProductShop
{
    using Newtonsoft.Json;
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;

    using Data;
    using Models;   
    using DTOs.Import;

    public class StartUp
    {
        public static void Main()
        {
            using ProductShopContext dbContext = new ProductShopContext();

            dbContext.Database.Migrate();
            Console.WriteLine("Database migrated successfully!");

            string jsonFile = File.ReadAllText("../../../Datasets/categories-products.json");
            string result = ImportCategoryProducts(dbContext, jsonFile);

            Console.WriteLine(result);
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            string result = string.Empty;

            ImportCategoryProductDto[]? catProdDtos = JsonConvert.DeserializeObject<ImportCategoryProductDto[]>(inputJson);

            if (catProdDtos != null)
            {
                ICollection<CategoryProduct> validCatProd = new List<CategoryProduct>();
                foreach (ImportCategoryProductDto catProdDto in catProdDtos)
                {
                    if (!IsValid(catProdDto))
                    {
                        continue;
                    }

                    bool isProductIdValid = int.TryParse(catProdDto.ProductId, out int productId);
                    bool isCategoryIdValid = int.TryParse(catProdDto.CategoryId, out int categoryId);

                    if ((!isProductIdValid) || (!isCategoryIdValid))
                    {
                        continue;
                    }

                    CategoryProduct catProd = new CategoryProduct()
                    {
                        ProductId = productId,
                        CategoryId = categoryId
                    };

                    validCatProd.Add(catProd);
                }

                context.CategoriesProducts.AddRange(validCatProd);
                context.SaveChanges();

                result = $"Successfully imported {validCatProd.Count}";
            }

            return result;
        }

        private static bool IsValid(object dto)
        {
            var validateContext = new ValidationContext(dto);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator
                .TryValidateObject(dto, validateContext, validationResults, true);

            return isValid;
        }
    }
}