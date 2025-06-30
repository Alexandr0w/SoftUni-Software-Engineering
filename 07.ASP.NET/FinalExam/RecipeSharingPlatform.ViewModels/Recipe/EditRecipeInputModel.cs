using System.ComponentModel.DataAnnotations;
using static RecipeSharingPlatform.GCommon.ValidationConstants.Recipe;

namespace RecipeSharingPlatform.ViewModels.Recipe
{
    public class EditRecipeInputModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(InstructionsMaxLength, MinimumLength = InstructionsMinLength)]
        public string Instructions { get; set; } = null!;

        public string? ImageUrl { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(CreatedOnLength, MinimumLength = CreatedOnLength)]
        public string CreatedOn { get; set; } = null!;

        public IEnumerable<AddCategoryDropDownModel>? Categories { get; set; }
    }
}
