using static NetPay.Common.ValidationConstants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetPay.Data.Models
{
    public class Household
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ContactPersonMaxLength)]
        public string ContactPerson { get; set; } = null!;

        [MaxLength(EmailMaxLength)]
        public string? Email { get; set; }

        [Required]
        [MaxLength(PhoneNumberLength)]
        [Column(TypeName = PhoneNumberType)]
        public string PhoneNumber { get; set; } = null!;

        public virtual ICollection<Expense> Expenses { get; set; } = new HashSet<Expense>();
    }
}
