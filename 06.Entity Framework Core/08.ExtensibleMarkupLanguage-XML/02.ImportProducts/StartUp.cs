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

            const string xmlFilePath = "../../../Datasets/products.xml";
            string inputXml = File.ReadAllText(xmlFilePath);

            string result = ImportProducts(dbContext, inputXml);
            Console.WriteLine(result);
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            string result = string.Empty;

            ImportProductDto[]? productDtos = XmlHelper.Deserialize<ImportProductDto[]>(inputXml, "Products");
            if (productDtos != null)
            {
                ICollection<Product> validProducts = new List<Product>();
                foreach (ImportProductDto productDto in productDtos)
                {
                    bool isPriceValid = decimal.TryParse(productDto.Price, out decimal productPrice);
                    bool isSellerValid = int.TryParse(productDto.SellerId, out int sellerId);
                    if ((!IsValid(productDto)) || (!isPriceValid) || (!isSellerValid))
                    {
                        continue;
                    }

                    int? buyerId = null;
                    if (productDto.BuyerId != null)
                    {
                        bool IsBuyerIdValid = int.TryParse(productDto.BuyerId, out int parsedBuyerId);
                        if (!IsBuyerIdValid)
                        {
                            continue;
                        }

                        buyerId = parsedBuyerId;
                    }

                    Product product = new Product()
                    {
                        Name = productDto.Name,
                        Price = productPrice,
                        SellerId = sellerId,
                        BuyerId = buyerId
                    };

                    validProducts.Add(product);
                }

                context.Products.AddRange(validProducts);
                context.SaveChanges();

                result = $"Successfully imported {validProducts.Count}";
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