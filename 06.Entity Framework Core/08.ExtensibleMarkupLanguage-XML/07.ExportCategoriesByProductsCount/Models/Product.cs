using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductShop.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public decimal Price { get; set; }

        [Required]
        [ForeignKey(nameof(Seller))]
        public int SellerId { get; set; }
        public virtual User Seller { get; set; } = null!;

        [ForeignKey(nameof(Buyer))]
        public int? BuyerId { get; set; }
        public virtual User Buyer { get; set; } = null!;

        public virtual ICollection<CategoryProduct> CategoryProducts { get; set; }
            = new HashSet<CategoryProduct>();
    }
}