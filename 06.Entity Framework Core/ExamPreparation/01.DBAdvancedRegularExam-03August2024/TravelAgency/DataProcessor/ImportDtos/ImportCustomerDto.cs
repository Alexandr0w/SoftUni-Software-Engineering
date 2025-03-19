using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using static TravelAgency.Common.ValidationConstants;

namespace TravelAgency.DataProcessor.ImportDtos
{
    [XmlType("Customer")]
    public class ImportCustomerDto
    {
        [Required]
        [XmlElement("FullName")]
        [StringLength(CustomerNameMaxLength, MinimumLength = CustomerNameMinLength)]
        public string FullName { get; set; } = null!;

        [Required]
        [XmlElement("Email")]
        [StringLength(CustomerEmailMaxLength, MinimumLength = CustomerEmailMinLength)]
        public string Email { get; set; } = null!;

        [Required]
        [XmlAttribute("phoneNumber")]
        [MaxLength(PhoneNumberMaxLength)]
        [RegularExpression(PhoneNumberPattern)]
        public string PhoneNumber { get; set; } = null!;
    }
}
