namespace RecipeSharingPlatform.ViewModels.Recipe
{
    public class DetailsRecipeViewModel : BaseInputModel
    {
        public string Instructions { get; set; } = null!;

        public string CreatedOn { get; set; } = null!;

        public string Author { get; set; } = null!;
    }
}
