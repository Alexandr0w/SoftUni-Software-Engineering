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

            string jsonFile = File.ReadAllText(@"../../../Datasets/cars.json");
            string result = ImportCars(dbContext, jsonFile);

            Console.WriteLine(result);
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            string result = string.Empty;

            ImportCarDto[]? carDtos = JsonConvert.DeserializeObject<ImportCarDto[]>(inputJson);

            ICollection<Car> cars = new List<Car>();
            ICollection<PartCar> parts = new List<PartCar>();
            ICollection<int> existingPartIds = context.Parts
                    .Select(p => p.Id)
                    .ToArray();

            if (carDtos != null)
            {
                foreach (var carDto in carDtos)
                {
                    if (!IsValid(carDto))
                    {
                        continue;
                    }

                    Car car = new Car()
                    {
                        Make = carDto.Make,
                        Model = carDto.Model,
                        TraveledDistance = carDto.TravelledDistance
                    };

                    cars.Add(car);

                    foreach (var carPart in carDto.PartIds.Distinct())
                    {
                        if (!existingPartIds.Contains(carPart))
                        {
                            continue; 
                        }

                        PartCar partCar = new PartCar()
                        {
                            Car = car,
                            PartId = carPart
                        };

                        parts.Add(partCar);
                    }
                }

                context.Cars.AddRange(cars);
                context.PartsCars.AddRange(parts);
                context.SaveChanges();

                result = $"Successfully imported {cars.Count}.";
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