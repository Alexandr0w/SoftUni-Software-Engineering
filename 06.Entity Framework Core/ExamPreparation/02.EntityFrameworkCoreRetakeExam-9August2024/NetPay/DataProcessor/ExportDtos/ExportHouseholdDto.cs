using NetPay.Data.Models;
using static NetPay.Common.ValidationConstants;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace NetPay.DataProcessor.ExportDtos
{
    [XmlType(nameof(Household))]
    public class ExportHouseholdDto
    {
        [XmlElement(nameof(ContactPerson))]
        [StringLength(ContactPersonMaxLength, MinimumLength = ContactPersonMinLength)]
        public string ContactPerson { get; set; } = null!;

        [XmlElement(nameof(Email))]
        [StringLength(EmailMaxLength, MinimumLength = EmailMinLength)]
        public string? Email { get; set; }

        [XmlElement(nameof(PhoneNumber))]
        [RegularExpression(PhoneNumberPattern)]
        [StringLength(PhoneNumberLength)]
        public string PhoneNumber { get; set; } = null!;

        [XmlArray(nameof(Expenses))]
        [XmlArrayItem(nameof(Expense))]
        public ExportExpenseDto[] Expenses { get; set; } = null!;
    }
}
