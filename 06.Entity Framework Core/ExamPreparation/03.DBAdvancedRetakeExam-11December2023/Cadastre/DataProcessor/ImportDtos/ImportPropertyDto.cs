using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using static Cadastre.Common.ValidationConstants;

namespace Cadastre.DataProcessor.ImportDtos
{
    public class ImportPropertyDto
    {
        [Required]
        [XmlElement(nameof(PropertyIdentifier))]
        [StringLength(PropertyIdentifierMaxLength, MinimumLength = PropertyIdentifierMinLength)]
        public string PropertyIdentifier { get; set; } = null!;

        [Required]
        [Range(0, int.MaxValue)]
        [XmlElement(nameof(Area))]
        public int Area { get; set; }

        [Required]
        [XmlElement(nameof(Details))]
        [StringLength(PropertyDetailsMaxLength, MinimumLength = PropertyAddressMinLength)]
        public string Details { get; set; } = null!;

        [Required]
        [XmlElement(nameof(Address))]
        [StringLength(PropertyAddressMaxLength, MinimumLength = PropertyAddressMinLength)]
        public string Address { get; set; } = null!;

        [Required]
        [XmlElement(nameof(DateOfAcquisition))]
        public string DateOfAcquisition { get; set; } = null!;
    }
}
