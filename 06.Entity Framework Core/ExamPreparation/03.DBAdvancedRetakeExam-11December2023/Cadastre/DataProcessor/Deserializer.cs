using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;
using Newtonsoft.Json;
using Cadastre.Data;
using Cadastre.Data.Enumerations;
using Cadastre.Data.Models;
using Cadastre.DataProcessor.ImportDtos;
using Cadastre.Utilities;

namespace Cadastre.DataProcessor
{
    public class Deserializer
    {
        private const string ErrorMessage =
            "Invalid Data!";
        private const string SuccessfullyImportedDistrict =
            "Successfully imported district - {0} with {1} properties.";
        private const string SuccessfullyImportedCitizen =
            "Succefully imported citizen - {0} {1} with {2} properties.";

        public static string ImportDistricts(CadastreContext dbContext, string xmlDocument)
        {
            StringBuilder sb = new StringBuilder();
            ImportDistrictDto[]? districtDtos = XmlHelper.Deserialize<ImportDistrictDto[]>(xmlDocument, "Districts");

            if (districtDtos != null && districtDtos.Length > 0)
            {
                ICollection<District> dbDistricts = new List<District>();

                foreach (ImportDistrictDto districtDto in districtDtos)
                {
                    if (!IsValid(districtDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (dbContext.Districts.Any(d => d.Name == districtDto.Name))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    District district = new District
                    {
                        Region = (Region)Enum.Parse(typeof(Region), districtDto.Region),
                        Name = districtDto.Name,
                        PostalCode = districtDto.PostalCode
                    };

                    foreach (var propertyDto in districtDto.Properties)
                    {
                        bool isDueDateValid = DateTime
                            .TryParseExact(propertyDto.DateOfAcquisition, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dueDate);

                        if (!IsValid(propertyDto) || !isDueDateValid)
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }

                        if (dbContext.Properties.Any(p => p.PropertyIdentifier == propertyDto.PropertyIdentifier)
                            || district.Properties.Any(dp => dp.PropertyIdentifier == propertyDto.PropertyIdentifier))
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }

                        if (dbContext.Properties.Any(p => p.Address == propertyDto.Address)
                            || district.Properties.Any(dp => dp.Address == propertyDto.Address))
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }

                        Property property = new Property
                        {
                            PropertyIdentifier = propertyDto.PropertyIdentifier,
                            Area = propertyDto.Area,
                            Details = propertyDto.Details,
                            Address = propertyDto.Address,
                            DateOfAcquisition = dueDate
                        };

                        district.Properties.Add(property);
                    }

                    dbDistricts.Add(district);
                    sb.AppendLine(string.Format(SuccessfullyImportedDistrict, district.Name, district.Properties.Count));
                }

                dbContext.Districts.AddRange(dbDistricts);
                dbContext.SaveChanges();
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportCitizens(CadastreContext dbContext, string jsonDocument)
        {
            StringBuilder sb = new StringBuilder();
            ImportCitizenDto[]? citizenDtos = JsonConvert.DeserializeObject<ImportCitizenDto[]>(jsonDocument);

            if (citizenDtos != null && citizenDtos.Length > 0)
            {
                ICollection<Citizen> dbCitizens = new List<Citizen>();

                foreach (ImportCitizenDto citizenDto in citizenDtos)
                {
                    bool isBirthDateValid = DateTime
                            .TryParseExact(citizenDto.BirthDate, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime birthDate);

                    if (!IsValid(citizenDto) || !isBirthDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Citizen citizen = new Citizen
                    {
                        FirstName = citizenDto.FirstName,
                        LastName = citizenDto.LastName,
                        BirthDate = birthDate,
                        MaritalStatus = (MaritalStatus)Enum.Parse(typeof(MaritalStatus), citizenDto.MaritalStatus)
                    };

                    foreach (var propertyId in citizenDto.Properties)
                    {
                        PropertyCitizen propertyCitizen = new PropertyCitizen
                        {
                            Citizen = citizen,
                            PropertyId = propertyId
                        };

                        citizen.PropertiesCitizens.Add(propertyCitizen);
                    }

                    dbCitizens.Add(citizen);
                    sb.AppendLine(string.Format(SuccessfullyImportedCitizen, citizen.FirstName, citizen.LastName, citizen.PropertiesCitizens.Count));
                }

                dbContext.Citizens.AddRange(dbCitizens);
                dbContext.SaveChanges();
            }

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
