using NetPay.Data.Models.Enums;
using static NetPay.Common.ValidationConstants;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace NetPay.DataProcessor.ImportDtos
{
    public class ImportExpenseDto
    {
        [Required]
        [JsonProperty(nameof(ExpenseName))]
        [StringLength(ExpenseNameMaxLength, MinimumLength = ExpenseNameMinLength)]
        public string ExpenseName { get; set; } = null!;

        [Required]
        [JsonProperty(nameof(Amount))]
        [Range(typeof(decimal), ExpenseAmountMin, ExpenseAmountMax)]
        public decimal Amount { get; set; }

        [Required]
        [JsonProperty(nameof(DueDate))]
        public string DueDate { get; set; } = null!;

        [Required]
        [JsonProperty(nameof(PaymentStatus))]
        [EnumDataType(typeof(PaymentStatus))]
        public string PaymentStatus { get; set; } = null!;

        [Required]
        [JsonProperty(nameof(HouseholdId))]
        public int HouseholdId { get; set; }

        [Required]
        [JsonProperty(nameof(ServiceId))]
        public int ServiceId { get; set; }
    }
}