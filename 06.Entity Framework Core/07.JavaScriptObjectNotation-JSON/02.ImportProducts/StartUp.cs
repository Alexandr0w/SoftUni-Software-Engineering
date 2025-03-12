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

            string productsJson = File.ReadAllText("../../../Datasets/products.json");
            string result = ImportProducts(dbContext, productsJson);

            Console.WriteLine(result);
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            string result = string.Empty;

            ImportProductDto[]? productDtos = JsonConvert.DeserializeObject<ImportProductDto[]>(inputJson);
            if (productDtos != null)
            {
                ICollection<Product> validProducts = new List<Product>();
                foreach (ImportProductDto productDto in productDtos)
                {
                    if (!IsValid(productDto))
                    {
                        continue;
                    }

                    bool isPriceValid = decimal.TryParse(productDto.Price, out decimal productPrice);
                    bool isSellerValid = int.TryParse(productDto.SellerId, out int sellerId);
                    if ((!isPriceValid) || (!isSellerValid))
                    {
                        continue;
                    }

                    int? buyerId = null;
                    if (productDto.BuyerId != null)
                    {
                        bool isBuyerIdValid = int.TryParse(productDto.BuyerId, out int parsedBuyerId);
                        if (!isBuyerIdValid)
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
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator
                .TryValidateObject(dto, validateContext, validationResults, true);

            return isValid;
        }
    }
}