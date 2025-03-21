using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static P03_SalesDatabase.Common.ValidationConstants.Product;

namespace P03_SalesDatabase.Data.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [Unicode(true)]
        [MaxLength(ProductNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [Column(TypeName = ProductQuantityType)]
        public decimal Quantity { get; set; }

        [Required]
        [Column(TypeName = ProductPriceType)]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(ProductDescMaxLength)]
        public string Description { get; set; } = null!;

        public virtual ICollection<Sale> Sales { get; set; } = new HashSet<Sale>();
    }
}