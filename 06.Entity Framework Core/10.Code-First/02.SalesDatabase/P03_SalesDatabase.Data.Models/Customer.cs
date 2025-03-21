using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static P03_SalesDatabase.Common.ValidationConstants.Customer;

namespace P03_SalesDatabase.Data.Models
{
    public class Customer
    {
        [Key] 
        public int CustomerId { get; set; }

        [Required]
        [Unicode(true)]
        [MaxLength(CustomerNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(CustomerEmailMaxLength)]
        public string Email { get; set; } = null!;

        public string CreditCardNumber { get; set; } = null!;

        public virtual ICollection<Sale> Sales { get; set; } = new HashSet<Sale>();
    }
}