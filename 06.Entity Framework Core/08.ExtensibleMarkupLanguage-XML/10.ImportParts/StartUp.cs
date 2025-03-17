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

            const string xmlFilePath = "../../../Datasets/parts.xml";
            string inputXml = File.ReadAllText(xmlFilePath);

            string result = ImportParts(dbContext, inputXml);
            Console.WriteLine(result);
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            string result = string.Empty;

            ImportPartDto[]? partDtos = XmlHelper.Deserialize<ImportPartDto[]>(inputXml, "Parts");

            if (partDtos != null)
            {
                ICollection<int> dbSupplierIds = context.Suppliers
                    .Select(s => s.Id)
                    .ToArray();

                ICollection<Part> validParts = new List<Part>();

                foreach (ImportPartDto partDto in partDtos)
                {
                    if (!IsValid(partDto))
                    {
                        continue;
                    }

                    bool isPriceValid = decimal.TryParse(partDto.Price, out decimal price);
                    bool isQuantityValid = int.TryParse(partDto.Quantity, out int quantity);
                    bool isSupplierIdValid = int.TryParse(partDto.SupplierId, out int supplierId);

                    if ((!isPriceValid) || (!isQuantityValid) || (!isSupplierIdValid))
                    {
                        continue;
                    }

                    if (!dbSupplierIds.Contains(supplierId))
                    {
                        continue;
                    }


                    Part part = new Part
                    {
                        Name = partDto.Name,
                        Price = price,
                        Quantity = quantity,
                        SupplierId = supplierId
                    };

                    validParts.Add(part);
                }

                context.Parts.AddRange(validParts);
                context.SaveChanges();

                result = $"Successfully imported {validParts.Count}";
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