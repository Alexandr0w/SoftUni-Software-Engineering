using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace CarDealer.DTOs.Import
{
    [XmlType("Customer")]
    public class ImportCustomerDto
    {
        [Required]
        [XmlElement("name")]
        public string Name { get; set; } = null!;

        [Required]
        [XmlElement("birthDate")]
        public string Birthdate { get; set; } = null!;

        [Required]
        [XmlElement("isYoungDriver")]
        public string IsYoungDriver { get; set; } = null!;
    }
}
