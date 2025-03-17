using System.ComponentModel.DataAnnotations.Schema;

namespace CarDealer.Models
{
    public class PartCar
    {
        // This entity has Composite PK defined using Fluent API
        [ForeignKey(nameof(Part))]
        public int PartId { get; set; }
        public virtual Part Part { get; set; } = null!;

        [ForeignKey(nameof(Car))]
        public int CarId { get; set; }
        public virtual Car Car { get; set; } = null!; 
    }
}
