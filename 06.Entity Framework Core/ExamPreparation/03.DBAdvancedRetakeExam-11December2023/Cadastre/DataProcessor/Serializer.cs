using Cadastre.Data;
using Cadastre.DataProcessor.ExportDtos;
using Cadastre.Utilities;
using Newtonsoft.Json;

namespace Cadastre.DataProcessor
{
    public class Serializer
    {
        public static string ExportPropertiesWithOwners(CadastreContext dbContext)
        {
            string result = string.Empty;

            var properties = dbContext.Properties
                .Where(p => p.DateOfAcquisition >= new DateTime(2000, 1, 1))
                .OrderByDescending(p => p.DateOfAcquisition)
                .ThenBy(p => p.PropertyIdentifier)
                .Select(p => new
                {
                    PropertyIdentifier = p.PropertyIdentifier,
                    Area = p.Area,
                    Address = p.Address,
                    DateOfAcquisition = p.DateOfAcquisition.ToString("dd/MM/yyyy"),
                    Owners = p.PropertiesCitizens
                        .Select(pc => pc.Citizen)
                        .OrderBy(c => c.LastName)
                        .Select(c => new
                        {
                            LastName = c.LastName,
                            MaritalStatus = c.MaritalStatus.ToString()
                        })
                        .ToArray()
                })
                .ToArray();

            result = JsonConvert.SerializeObject(properties, Formatting.Indented);
            return result;
        }

        public static string ExportFilteredPropertiesWithDistrict(CadastreContext dbContext)
        {
            string result = string.Empty;

            ExportPropertyDto[] propertyDtos = dbContext.Properties
                .Where(p => p.Area >= 100)
                .OrderByDescending(p => p.Area)
                .ThenBy(p => p.DateOfAcquisition)
                .Select(p => new ExportPropertyDto
                {
                    PostalCode = p.District.PostalCode,
                    PropertyIdentifier = p.PropertyIdentifier,
                    Area = p.Area,
                    DateOfAcquisition = p.DateOfAcquisition.ToString("dd/MM/yyyy")
                })
            .ToArray();

            result = XmlHelper.Serialize(propertyDtos, "Properties");
            return result;
        }
    }
}
