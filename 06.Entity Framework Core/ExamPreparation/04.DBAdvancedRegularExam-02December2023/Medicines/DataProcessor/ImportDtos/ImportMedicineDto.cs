using Medicines.Data.Models;
using static Medicines.Common.ValidationConstants;
using System.Xml.Serialization;
using System.ComponentModel.DataAnnotations;

namespace Medicines.DataProcessor.ImportDtos
{
    [XmlType(nameof(Medicine))]
    public class ImportMedicineDto
    {
        [Required]
        [XmlAttribute("category")]
        [Range(MedicineCategoryMinValue, MedicineCategoryMaxValue)]
        public int Category { get; set; }

        [Required]
        [XmlElement(nameof(Name))]
        [StringLength(MedicineNameMaxLength, MinimumLength = MedicineNameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [XmlElement(nameof(Price))]
        [Range(typeof(decimal), MedicinePriceMinValue, MedicinePriceMaxValue)]
        public decimal Price { get; set; }

        [Required]
        [XmlElement(nameof(ProductionDate))]
        public string ProductionDate { get; set; } = null!;

        [Required]
        [XmlElement(nameof(ExpiryDate))]
        public string ExpiryDate { get; set; } = null!;

        [Required]
        [XmlElement(nameof(Producer))]
        [StringLength(MedicineProducerMaxLength, MinimumLength = MedicineProducerMinLength)]
        public string Producer { get; set; } = null!;
    }
}
