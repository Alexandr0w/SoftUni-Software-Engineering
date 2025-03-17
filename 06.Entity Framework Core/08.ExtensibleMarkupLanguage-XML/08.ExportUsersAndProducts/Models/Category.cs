using System.ComponentModel.DataAnnotations;

namespace ProductShop.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public ICollection<CategoryProduct> CategoryProducts { get; set; }
            = new HashSet<CategoryProduct>();
    }
}
