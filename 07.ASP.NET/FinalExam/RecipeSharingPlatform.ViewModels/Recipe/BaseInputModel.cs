namespace RecipeSharingPlatform.ViewModels.Recipe
{
    public abstract class BaseInputModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string? ImageUrl { get; set; }

        public string Category { get; set; } = null!;

        public bool IsAuthor { get; set; }

        public bool IsSaved { get; set; }
    }
}
