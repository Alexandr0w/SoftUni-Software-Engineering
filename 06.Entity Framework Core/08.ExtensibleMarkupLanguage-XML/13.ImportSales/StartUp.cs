using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using CarDealer.Utilities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            using CarDealerContext dbContext = new CarDealerContext();
            dbContext.Database.Migrate();

            Console.WriteLine("Database migrated to the latest version successfully!");

            const string xmlFilePath = "../../../Datasets/sales.xml";
            string inputXml = File.ReadAllText(xmlFilePath);

            string result = ImportSales(dbContext, inputXml);
            Console.WriteLine(result);
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            string result = string.Empty;

            ImportSaleDto[]? saleDtos = XmlHelper.Deserialize<ImportSaleDto[]>(inputXml, "Sales");

            if (saleDtos != null)
            {
                ICollection<int> dbCarIds = context.Cars
                    .Select(c => c.Id)
                    .ToArray();

                ICollection<Sale> validSales = new List<Sale>();

                foreach (ImportSaleDto saleDto in saleDtos)
                {
                    if (!IsValid(saleDto))
                    {
                        continue;
                    }

                    bool isCustomerIdValid = int.TryParse(saleDto.CustomerId, out int customerId);
                    bool isCarIdValid = int.TryParse(saleDto.CarId, out int carId);
                    bool isDiscountValid = decimal.TryParse(saleDto.Discount, out decimal discount);

                    if ((!isCustomerIdValid) || (!isCarIdValid) || (!isDiscountValid))
                    {
                        continue;
                    }

                    if (!dbCarIds.Contains(carId))
                    {
                        continue;
                    }

                    Sale sale = new Sale
                    {
                        CarId = carId,
                        CustomerId = customerId,
                        Discount = discount
                    };

                    validSales.Add(sale);
                }

                context.Sales.AddRange(validSales);
                context.SaveChanges();
                
                result = $"Successfully imported {validSales.Count}";
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