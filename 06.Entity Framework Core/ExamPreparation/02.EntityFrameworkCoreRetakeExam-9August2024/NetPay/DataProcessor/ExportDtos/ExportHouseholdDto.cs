using System.Xml.Serialization;

namespace NetPay.DataProcessor.ExportDtos
{
    [XmlType("Household")]
    public class ExportHouseholdDto
    {
        [XmlElement(nameof(ContactPerson))]
        public string ContactPerson { get; set; } = null!;

        [XmlElement(nameof(Email))]
        public string? Email { get; set; }

        [XmlElement(nameof(PhoneNumber))]
        public string PhoneNumber { get; set; } = null!;

        [XmlArray("Expenses")]
        [XmlArrayItem("Expense")]
        public ExportExpenseDto[] UnpaidExpenses { get; set; } = null!;
    }
}
