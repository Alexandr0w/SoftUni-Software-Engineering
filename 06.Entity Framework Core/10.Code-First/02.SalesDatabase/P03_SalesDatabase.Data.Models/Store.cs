using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static P03_SalesDatabase.Common.ValidationConstants.Store;

namespace P03_SalesDatabase.Data.Models
{
    public class Store
    {
        [Key]
        public int StoreId { get; set; }

        [Required]
        [Unicode(true)]
        [MaxLength(StoreNameMaxLength)]
        public string Name { get; set; } = null!;

        public virtual ICollection<Sale> Sales { get; set; } = new HashSet<Sale>();
    }
}
