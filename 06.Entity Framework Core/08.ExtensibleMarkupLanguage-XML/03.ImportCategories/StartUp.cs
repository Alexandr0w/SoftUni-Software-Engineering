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

            const string xmlFilePath = "../../../Datasets/categories.xml";
            string inputXml = File.ReadAllText(xmlFilePath);

            string result = ImportCategories(dbContext, inputXml);
            Console.WriteLine(result);
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            string result = string.Empty;

            ImportCategoryDto[]? categoryDtos = XmlHelper.Deserialize<ImportCategoryDto[]>(inputXml, "Categories");

            if (categoryDtos != null)
            {
                ICollection<Category> validCategories = new List<Category>();

                foreach (ImportCategoryDto categoryDto in categoryDtos)
                {
                    if (!IsValid(categoryDto))
                    {
                        continue;
                    }

                    Category category = new Category
                    {
                        Name = categoryDto.Name
                    };

                    validCategories.Add(category);
                }

                context.Categories.AddRange(validCategories);
                context.SaveChanges();

                result = $"Successfully imported {validCategories.Count}";
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