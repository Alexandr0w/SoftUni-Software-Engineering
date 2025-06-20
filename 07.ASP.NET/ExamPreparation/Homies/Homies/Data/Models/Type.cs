namespace Homies.Data.Models
{
    using static Common.ValidationConstants.Type;
    using System.ComponentModel.DataAnnotations;

    public class Type
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public ICollection<Event> Events { get; set; } 
            = new HashSet<Event>();
    }
}
