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

            const string xmlFilePath = "../../../Datasets/suppliers.xml";
            string inputXml = File.ReadAllText(xmlFilePath);

            string result = ImportSuppliers(dbContext, inputXml);
            Console.WriteLine(result);
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            string result = string.Empty;

            ImportSupplierDto[]? supplierDtos = XmlHelper.Deserialize<ImportSupplierDto[]>(inputXml, "Suppliers");

            if (supplierDtos != null)
            {
                ICollection<Supplier> validSuppliers = new List<Supplier>();

                foreach (ImportSupplierDto supplierDto in supplierDtos)
                {
                    if (!IsValid(supplierDto))
                    {
                        continue;
                    }

                    Supplier supplier = new Supplier()
                    {
                        Name = supplierDto.Name,
                        IsImporter = supplierDto.IsImporter,
                    };

                    validSuppliers.Add(supplier);
                }

                context.Suppliers.AddRange(validSuppliers);
                context.SaveChanges();

                result = $"Successfully imported {validSuppliers.Count}";
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