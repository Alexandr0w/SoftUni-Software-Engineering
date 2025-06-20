namespace Homies.Models.Event
{
    using System.ComponentModel.DataAnnotations;
    using static Common.ValidationConstants.Event;

    public class EventAddInputModel
    {
        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        public string Start { get; set; } = null!;

        [Required]
        public string End { get; set; } = null!;

        [Required]
        public int TypeId { get; set; }

        public virtual IEnumerable<TypeViewModel> Types { get; set; } = new List<TypeViewModel>();
    }
}
