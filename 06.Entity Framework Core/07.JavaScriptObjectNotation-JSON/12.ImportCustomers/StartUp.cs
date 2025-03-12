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

            string jsonFile = File.ReadAllText(@"../../../Datasets/customers.json");
            string result = ImportCustomers(dbContext, jsonFile);

            Console.WriteLine(result);
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            string result = string.Empty;

            ImportCustomerDto[]? customerDtos = JsonConvert.DeserializeObject<ImportCustomerDto[]>(inputJson);

            ICollection<Customer> customers = new List<Customer>();

            if (customerDtos != null)
            {
                foreach (ImportCustomerDto customerDto in customerDtos)
                {
                    if (!IsValid(customerDto))
                    {
                        continue;
                    }

                    Customer customer = new Customer
                    {
                        Name = customerDto.Name,
                        BirthDate = customerDto.BirthDate,
                        IsYoungDriver = customerDto.IsYoungDriver
                    };

                    customers.Add(customer);
                }

                context.Customers.AddRange(customers);
                context.SaveChanges();

                result = $"Successfully imported {customers.Count}.";
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