using System.ComponentModel.DataAnnotations;
using static TravelAgency.Common.ValidationConstants;

namespace TravelAgency.Data.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(CustomerNameMaxLength, MinimumLength = CustomerNameMinLength)]
        public string FullName { get; set; } = null!;

        [Required]
        [StringLength(CustomerEmailMaxLength, MinimumLength = CustomerEmailMinLength)]
        public string Email { get; set; } = null!;

        [Required]
        [MaxLength(PhoneNumberMaxLength)]
        [RegularExpression(PhoneNumberPattern)]
        public string PhoneNumber { get; set; } = null!;

        public ICollection<Booking> Bookings { get; set; } = new HashSet<Booking>();
    }
}
