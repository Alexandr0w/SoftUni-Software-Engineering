using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using CarDealer.Utilities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

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
                ICollection<Customer> validCustomers = new List<Customer>();

                foreach (ImportCustomerDto customerDto in customerDtos)
                {
                    if (!IsValid(customerDto))
                    {
                        continue;
                    }

                    bool isBirthDateValid = DateTime
                        .TryParse(customerDto.Birthdate, CultureInfo.InvariantCulture, DateTimeStyles.None, 
                            out DateTime birthDate);
                    
                    if (!isBirthDateValid)
                    {
                        continue;
                    }

                    bool isYoungDriverValid = bool
                        .TryParse(customerDto.IsYoungDriver, out bool isYoungDriver);
                    
                    if (!isYoungDriverValid)
                    {
                        continue;
                    }

                    Customer customer = new Customer
                    {
                        Name = customerDto.Name,
                        BirthDate = birthDate,
                        IsYoungDriver = isYoungDriver
                    };

                    validCustomers.Add(customer);
                }
                
                context.Customers.AddRange(validCustomers);
                context.SaveChanges();

                result = $"Successfully imported {validCustomers.Count}";
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