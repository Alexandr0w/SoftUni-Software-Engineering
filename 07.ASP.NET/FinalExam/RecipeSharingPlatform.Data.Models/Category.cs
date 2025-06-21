namespace RecipeSharingPlatform.Data.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public virtual ICollection<Recipe> Recipes { get; set; } = new HashSet<Recipe>();
    }
}
