using NetPay.Data.Models;
using static NetPay.Common.ValidationConstants;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace NetPay.DataProcessor.ExportDtos
{
    [XmlType(nameof(Expense))]
    public class ExportExpenseDto
    {
        [XmlElement(nameof(ExpenseName))]
        [StringLength(ExpenseNameMaxLength, MinimumLength = ExpenseNameMinLength)]
        public string ExpenseName { get; set; } = null!;

        [XmlElement(nameof(Amount))]
        [Range(typeof(decimal), ExpenseAmountMin, ExpenseAmountMax)]
        public string Amount { get; set; } = null!;

        [XmlElement(nameof(PaymentDate))]
        public string PaymentDate { get; set; } = null!;

        [XmlElement(nameof(ServiceName))]
        [StringLength(ServiceNameMaxLength, MinimumLength = ServiceNameMinLength)]
        public string ServiceName { get; set; } = null!;
    }
}
