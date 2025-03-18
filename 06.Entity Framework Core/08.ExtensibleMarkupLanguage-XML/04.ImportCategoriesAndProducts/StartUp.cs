using ProductShop.Data;
using ProductShop.DTOs.Import;
using ProductShop.Models;
using ProductShop.Utilities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            using ProductShopContext dbContext = new ProductShopContext();
            dbContext.Database.Migrate();

            Console.WriteLine("Database migrated to the latest version successfully!");

            const string xmlFilePath = "../../../Datasets/categories-products.xml";
            string inputXml = File.ReadAllText(xmlFilePath);

            string result = ImportCategoryProducts(dbContext, inputXml);
            Console.WriteLine(result);
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            string result = string.Empty;

            ImportCategoryProductDto[]? catProdDtos = XmlHelper.Deserialize<ImportCategoryProductDto[]>(inputXml, "CategoryProducts");

            if (catProdDtos != null)
            {
                ICollection<CategoryProduct> validCatProd = new List<CategoryProduct>();

                foreach (ImportCategoryProductDto catProdDto in catProdDtos)
                {
                    bool isProductIdValid = int.TryParse(catProdDto.ProductId, out int productId);
                    bool isCategoryIdValid = int.TryParse(catProdDto.CategoryId, out int categoryId);

                    if ((!IsValid(catProdDto) || (!isProductIdValid) || (!isCategoryIdValid)))
                    {
                        continue;
                    }

                    CategoryProduct categoryProduct = new CategoryProduct
                    {
                        CategoryId = categoryId,
                        ProductId = productId
                    };

                    validCatProd.Add(categoryProduct);
                }

                context.CategoryProducts.AddRange(validCatProd);
                context.SaveChanges();

                result = $"Successfully imported {validCatProd.Count}";
            }

            return result;
        }

        private static bool IsValid(object dto)
        {
            var validateContext = new ValidationContext(dto);
            var validateResults = new List<ValidationResult>();

            bool isValid = Validator
                .TryValidateObject(dto, validateContext, validateResults, true);

            return isValid;
        }
    }
}