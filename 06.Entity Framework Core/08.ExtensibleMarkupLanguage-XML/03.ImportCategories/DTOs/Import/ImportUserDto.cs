using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace ProductShop.DTOs.Import
{
    [XmlType("User")]
    public class ImportUserDto
    {
        [Required]
        [XmlElement("firstName")]
        public string FirstName { get; set; } = null!;

        [Required]
        [XmlElement("lastName")]
        public string LastName { get; set; } = null!;

        [Required]
        [XmlElement("age")]
        public string Age { get; set; } = null!;
    }
}


