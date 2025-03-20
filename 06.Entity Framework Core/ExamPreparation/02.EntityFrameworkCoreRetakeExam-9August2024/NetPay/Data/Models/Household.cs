using System.ComponentModel.DataAnnotations;
using static NetPay.Common.ValidationConstants;

namespace NetPay.Data.Models
{
    public class Household
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(ContactPersonMaxLength, MinimumLength = ContactPersonMinLength)]
        public string ContactPerson { get; set; } = null!;

        [StringLength(EmailMaxLength, MinimumLength = EmailMinLength)]
        public string? Email { get; set; }

        [Required]
        [StringLength(PhoneNumberLength, MinimumLength = PhoneNumberLength)]
        [RegularExpression(PhoneNumberPattern)]
        public string PhoneNumber { get; set; } = null!;

        public ICollection<Expense> Expenses { get; set; } = new HashSet<Expense>();
    }
}
