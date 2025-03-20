using static NetPay.Common.ValidationConstants;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace NetPay.DataProcessor.ImportDtos
{
    [XmlType("Household")]
    public class ImportHouseholdDto
    {
        [XmlAttribute("phone")]
        [StringLength(PhoneNumberLength, MinimumLength = PhoneNumberLength)]
        [RegularExpression(PhoneNumberPattern)]
        public string PhoneNumber { get; set; } = null!;

        [XmlElement(nameof(ContactPerson))]
        [StringLength(ContactPersonMaxLength, MinimumLength = ContactPersonMinLength)]
        public string ContactPerson { get; set; } = null!;

        [XmlElement(nameof(Email))]
        [StringLength(EmailMaxLength, MinimumLength = EmailMinLength)]
        public string Email { get; set; } = null!;
    }
}
