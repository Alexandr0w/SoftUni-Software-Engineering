using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cadastre.Data.Models
{
    public class PropertyCitizen
    {
        [Required]
        [ForeignKey(nameof(Property))]
        public int PropertyId { get; set; }
        public virtual Property Property { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Citizen))]
        public int CitizenId { get; set; }

        public virtual Citizen Citizen { get; set; } = null!;
    }
}
