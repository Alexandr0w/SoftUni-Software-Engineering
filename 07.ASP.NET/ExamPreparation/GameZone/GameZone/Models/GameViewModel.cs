namespace GameZone.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Common.ValidationConstants.Game;

    public class GameViewModel
    {
        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        public string Title { get; set; } = string.Empty;

        public string? ImageUrl { get; set; }

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string ReleasedOn { get; set; } = string.Empty;

        [Required]
        [Range(1, int.MaxValue)]
        public int GenreId { get; set; }

        public virtual IEnumerable<GenreViewModel>? Genres { get; set; } = null!;
    }
}
