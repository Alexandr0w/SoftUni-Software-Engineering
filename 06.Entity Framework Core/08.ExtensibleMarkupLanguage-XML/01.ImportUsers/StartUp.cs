using ProductShop.Data;
using ProductShop.DTOs.Import;
using ProductShop.Models;
using ProductShop.Utilities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            using ProductShopContext dbContext = new ProductShopContext();
            dbContext.Database.Migrate();

            Console.WriteLine("Database migrated to the latest version successfully!");

            const string xmlFilePath = "../../../Datasets/users.xml";
            string inputXml = File.ReadAllText(xmlFilePath);

            string result = ImportUsers(dbContext, inputXml);
            Console.WriteLine(result);
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            string result = string.Empty;

            ImportUserDto[]? userDtos = XmlHelper.Deserialize<ImportUserDto[]>(inputXml, "Users");

            if (userDtos != null)
            {
                ICollection<User> validUsers = new List<User>();

                foreach (ImportUserDto userDto in userDtos)
                {
                    int? userAge = null;

                    if (userDto.Age != null)
                    {
                        bool isAgeValid = int.TryParse(userDto.Age, out int parsedAge);

                        if (!isAgeValid || !IsValid(userDto))
                        {
                            continue;
                        }

                        userAge = parsedAge;
                    }

                    User user = new User()
                    {
                        FirstName = userDto.FirstName,
                        LastName = userDto.LastName,
                        Age = userAge
                    };

                    validUsers.Add(user);
                }

                context.Users.AddRange(validUsers);
                context.SaveChanges();

                result = $"Successfully imported {validUsers.Count}";
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