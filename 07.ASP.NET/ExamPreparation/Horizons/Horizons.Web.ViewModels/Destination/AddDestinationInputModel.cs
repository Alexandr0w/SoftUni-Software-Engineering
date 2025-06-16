namespace Horizons.Web.ViewModels.Destination
{
    using System.ComponentModel.DataAnnotations;
    using static GCommon.ValidationConstants.Destination;

    public class AddDestinationInputModel
    {
        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        
        public string Description { get; set; } = null!;

        public string? ImageUrl { get; set; }

        [Required]
        [StringLength(PublishedOnLength, MinimumLength = PublishedOnLength)]
        public string PublishedOn { get; set; } = null!;

        public int TerrainId { get; set; }

        public IEnumerable<AddDestinationTerrainDropDownModel>? Terrains { get; set; }
    }
}
