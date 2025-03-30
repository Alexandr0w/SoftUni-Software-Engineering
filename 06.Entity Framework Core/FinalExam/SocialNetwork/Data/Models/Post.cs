using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SocialNetwork.Common.ValidationConstants;

namespace SocialNetwork.Data.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(PostContentMaxLength)]
        public string Content { get; set; } = null!;

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        [ForeignKey(nameof(Creator))]
        public int CreatorId { get; set; }
        public virtual User Creator { get; set; } = null!;
    }
}