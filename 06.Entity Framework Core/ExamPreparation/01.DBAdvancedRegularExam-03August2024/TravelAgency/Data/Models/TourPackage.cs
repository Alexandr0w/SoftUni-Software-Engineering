using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static TravelAgency.Common.ValidationConstants;

namespace TravelAgency.Data.Models
{
    public class TourPackage
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(PackageNameMaxLength, MinimumLength = PackageNameMinLength)]
        public string PackageName { get; set; } = null!;

        [MaxLength(DescriptionMaxLength)]
        public string? Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Range(0.01, double.MaxValue, ParseLimitsInInvariantCulture = true)]
        public decimal Price { get; set; }

        public ICollection<Booking> Bookings { get; set; } = new HashSet<Booking>();
        public ICollection<TourPackageGuide> TourPackagesGuides { get; set; } = new HashSet<TourPackageGuide>();
    }
}
