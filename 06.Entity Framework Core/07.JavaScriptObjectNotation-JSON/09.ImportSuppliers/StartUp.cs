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

            string jsonFile = File.ReadAllText(@"../../../Datasets/suppliers.json");
            string result = ImportSuppliers(dbContext, jsonFile);

            Console.WriteLine(result);
        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            string result = string.Empty;

            ImportSupplierDto[]? supplierDtos = JsonConvert.DeserializeObject<ImportSupplierDto[]>(inputJson);

            if (supplierDtos != null)
            {
                ICollection<Supplier> suppliers = new List<Supplier>();
                foreach (ImportSupplierDto supplierDto in supplierDtos)
                {
                    if (!IsValid(supplierDto))
                    {
                        continue;
                    }

                    Supplier supplier = new Supplier
                    {
                        Name = supplierDto.Name,
                        IsImporter = supplierDto.IsImporter
                    };

                    suppliers.Add(supplier);
                }

                context.Suppliers.AddRange(suppliers);
                context.SaveChanges();

                result = $"Successfully imported {suppliers.Count}.";
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