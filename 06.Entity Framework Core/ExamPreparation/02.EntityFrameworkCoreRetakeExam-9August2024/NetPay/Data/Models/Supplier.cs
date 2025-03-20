using static NetPay.Common.ValidationConstants;
using System.ComponentModel.DataAnnotations;

namespace NetPay.Data.Models
{
    public class Supplier
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(SupplierNameMaxLength, MinimumLength = SupplierNameMinLength)]
        public string SupplierName { get; set; } = null!;

        public ICollection<SupplierService> SuppliersServices { get; set; } = new HashSet<SupplierService>();
    }
}

