using NetPay.Data.Models.Enums;
using static NetPay.Common.ValidationConstants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetPay.Data.Models
{
    public class Expense
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(ExpenseNameMaxLength, MinimumLength = ExpenseNameMinLength)]
        public string ExpenseName { get; set; } = null!;

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Range(typeof(decimal), ExpenseAmountMin, ExpenseAmountMax)]
        public decimal Amount { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        [Required]
        public PaymentStatus PaymentStatus { get; set; }

        [Required]
        [ForeignKey(nameof(HouseholdId))]
        public int HouseholdId { get; set; }
        public Household Household { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(ServiceId))]
        public int ServiceId { get; set; }
        public Service Service { get; set; } = null!;
    }
}