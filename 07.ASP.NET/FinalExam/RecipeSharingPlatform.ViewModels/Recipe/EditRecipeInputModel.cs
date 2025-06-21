namespace RecipeSharingPlatform.ViewModels.Recipe
{
    public class EditRecipeInputModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string Instructions { get; set; } = null!;

        public string? ImageUrl { get; set; }

        public int CategoryId { get; set; }

        public string CreatedOn { get; set; } = null!;

        public IEnumerable<AddCategoryDropDownModel>? Categories { get; set; }
    }
}
