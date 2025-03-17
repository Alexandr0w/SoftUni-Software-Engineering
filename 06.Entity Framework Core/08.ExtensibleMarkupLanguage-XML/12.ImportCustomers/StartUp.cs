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

            const string xmlFilePath = "../../../Datasets/customers.xml";
            string inputXml = File.ReadAllText(xmlFilePath);

            string result = ImportCustomers(dbContext, inputXml);
            Console.WriteLine(result);
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            string result = string.Empty;

            ImportCustomerDto[]? customerDtos = XmlHelper.Deserialize<ImportCustomerDto[]>(inputXml, "Customers");

            if (customerDtos != null)
            {
                ICollection<Customer> customersToAdd = new List<Customer>();

                foreach (var customerDto in customerDtos)
                {
                    if (!IsValid(customerDto))
                    {
                        continue;
                    }

                    var isbirthDateValid = DateTime.TryParse(customerDto.Birthdate, out DateTime birthDate);
                    var isYoungDriverValid = bool.TryParse(customerDto.IsYoungDriver, out bool isYoungDriver);

                    if (!isbirthDateValid || !isYoungDriverValid)
                    {
                        continue;
                    }

                    Customer customer = new Customer()
                    {
                        Name = customerDto.Name,
                        BirthDate = birthDate,
                        IsYoungDriver = isYoungDriver
                    };

                    customersToAdd.Add(customer);
                }

                context.Customers.AddRange(customersToAdd);
                context.SaveChanges();

                result = $"Successfully imported {customersToAdd.Count}";
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