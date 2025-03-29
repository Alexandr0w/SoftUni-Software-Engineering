using Medicines.Data.Models;
using static Medicines.Common.ValidationConstants;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Medicines.DataProcessor.ImportDtos
{
    [XmlType(nameof(Pharmacy))]
    public class ImportPharmacyDto
    {
        [Required]
        [XmlElement(nameof(Name))]
        [StringLength(PharmacyNameMaxLength, MinimumLength = PharmacyNameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [XmlElement(nameof(PhoneNumber))]
        [RegularExpression(PharmacyPhoneNumberRegex)]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [XmlAttribute("non-stop")]
        [RegularExpression(PharmacyBooleanRegex)]
        public string IsNonStop { get; set; } = null!;

        [XmlArray(nameof(Medicines))]
        [XmlArrayItem(nameof(Medicine))]
        public ImportMedicineDto[] Medicines { get; set; } = null!;
    }
}
