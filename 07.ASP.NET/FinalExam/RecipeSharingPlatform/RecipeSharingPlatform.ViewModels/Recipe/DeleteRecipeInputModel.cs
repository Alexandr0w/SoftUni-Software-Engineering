namespace RecipeSharingPlatform.ViewModels.Recipe
{
    public class DeleteRecipeInputModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string? Author { get; set; }

        public string AuthorId { get; set; } = null!;

    }
}
