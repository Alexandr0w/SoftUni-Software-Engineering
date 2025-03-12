namespace CarDealer
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
            using CarDealerContext dbContext = new CarDealerContext();

            dbContext.Database.Migrate();
            Console.WriteLine("Database migrated successfully!");

            string jsonFile = File.ReadAllText(@"../../../Datasets/sales.json");
            string result = ImportSales(dbContext, jsonFile);

            Console.WriteLine(result);
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            string result = string.Empty;

            ImportSaleDto[]? saleDtos = JsonConvert.DeserializeObject<ImportSaleDto[]>(inputJson);

            ICollection<Sale> sales = new List<Sale>();

            if (saleDtos != null)
            {
                foreach (ImportSaleDto saleDto in saleDtos)
                {
                    if (!IsValid(saleDto))
                    {
                        continue;
                    }

                    Sale sale = new Sale
                    {
                        CarId = saleDto.CarId,
                        CustomerId = saleDto.CustomerId,
                        Discount = saleDto.Discount
                    };

                    sales.Add(sale);
                }

                context.Sales.AddRange(sales);
                context.SaveChanges();

                result = $"Successfully imported {sales.Count}.";
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