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

            string jsonFile = File.ReadAllText(@"../../../Datasets/parts.json");
            string result = ImportParts(dbContext, jsonFile);

            Console.WriteLine(result);
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            string result = string.Empty;

            ImportPartDto[]? partDtos = JsonConvert.DeserializeObject<ImportPartDto[]>(inputJson);

            if (partDtos != null)
            {
                List<int> supplierListIds = context.Suppliers
                    .Select(s => s.Id)
                    .ToList();

                List<Part> parts = JsonConvert
                    .DeserializeObject<List<Part>>(inputJson)!
                    .Where(p => supplierListIds.Contains(p.SupplierId))
                    .ToList();

                foreach (ImportPartDto partDto in partDtos)
                {
                    if (!IsValid(partDto))
                    {
                        continue;
                    }
                }

                context.AddRange(parts);
                context.SaveChanges();

                result = $"Successfully imported {parts.Count}.";
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