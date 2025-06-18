namespace GameZone.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static Common.ValidationConstants.Game;

    public class Game
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        public string? ImageUrl { get; set; }

        [Required]
        [ForeignKey(nameof(Publisher))]
        public string PublisherId { get; set; } = null!;
        public virtual IdentityUser Publisher { get; set; } = null!;

        [Required]
        public DateTime ReleasedOn { get; set; }

        [Required]
        [ForeignKey(nameof(Genre))]
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; } = null!;

        public bool IsDeleted { get; set; }

        public virtual ICollection<GamerGame> GamersGames { get; set; }
            = new HashSet<GamerGame>();
    }
}
