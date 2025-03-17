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

            const string xmlFilePath = "../../../Datasets/cars.xml";
            string inputXml = File.ReadAllText(xmlFilePath);

            string result = ImportCars(dbContext, inputXml);
            Console.WriteLine(result);
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            string result = string.Empty;

            ImportCarDto[]? carDtos = XmlHelper.Deserialize<ImportCarDto[]>(inputXml, "Cars");

            if (carDtos != null)
            {
                ICollection<int> dbPartIds = context.Parts
                    .Select(p => p.Id)
                    .ToArray();

                ICollection<Car> validCars = new List<Car>();

                foreach (ImportCarDto carDto in carDtos)
                {
                    if (!IsValid(carDto))
                    {
                        continue;
                    }

                    bool isTraveledDistanceValid = long.TryParse(carDto.TraveledDistance, out long traveledDistance);
                    if (!isTraveledDistanceValid)
                    {
                        continue;
                    }

                    Car car = new Car()
                    {
                        Make = carDto.Make,
                        Model = carDto.Model,
                        TraveledDistance = traveledDistance
                    };

                    if (carDto.Parts != null)
                    {
                        int[] partIds = carDto.Parts
                            .Where(p => IsValid(p) && int.TryParse(p.Id, out int dummy))
                            .Select(p => int.Parse(p.Id))
                            .Distinct()
                            .ToArray();

                        foreach (int partId in partIds)
                        {
                            if (!dbPartIds.Contains(partId))
                            {
                                continue;
                            }

                            PartCar partCar = new PartCar()
                            {
                                PartId = partId,
                                Car = car
                            };

                            car.PartsCars.Add(partCar);
                        }
                    }

                    validCars.Add(car);
                }

                context.Cars.AddRange(validCars);
                context.SaveChanges();

                result = $"Successfully imported {validCars.Count}";
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