using System.ComponentModel.DataAnnotations;
using static Cadastre.Common.ValidationConstants;
using Cadastre.Data.Enumerations;

namespace Cadastre.Data.Models
{
    public class District
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(DistrictNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        public string PostalCode { get; set; } = null!;

        [Required]
        public Region Region { get; set; }

        public virtual ICollection<Property> Properties { get; set; } = new HashSet<Property>();
    }
}