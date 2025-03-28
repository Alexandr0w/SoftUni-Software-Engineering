using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Cadastre.Data.Models;
using static Cadastre.Common.ValidationConstants;

namespace Cadastre.DataProcessor.ImportDtos
{
    [XmlType(nameof(District))]
    public class ImportDistrictDto
    {
        [Required]
        [XmlElement(nameof(Name))]
        [StringLength(DistrictNameMaxLength, MinimumLength = DistrictNameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [XmlElement(nameof(PostalCode))]
        [RegularExpression(DistrictPostalCodeRegex)]
        public string PostalCode { get; set; } = null!;

        [Required]
        [XmlAttribute(nameof(Region))]
        public string Region { get; set; } = null!;

        [Required]
        [XmlArray(nameof(Properties))]
        [XmlArrayItem(nameof(Property))]
        public ImportPropertyDto[] Properties { get; set; } = null!;
    }
}
