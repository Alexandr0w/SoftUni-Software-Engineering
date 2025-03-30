using System.ComponentModel.DataAnnotations;
using static SocialNetwork.Common.ValidationConstants;

namespace SocialNetwork.Data.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(UserUsernameMaxLength)]
        public string Username { get; set; } = null!;

        [Required]
        [MaxLength(UserEmailMaxLength)]
        public string Email { get; set; } = null!;

        [Required]
        [MinLength(UserPasswordLength)]
        public string Password { get; set; } = null!;

        public virtual ICollection<Post> Posts { get; set; } = new HashSet<Post>();
        public virtual ICollection<Message> Messages { get; set; } = new HashSet<Message>();
        public virtual ICollection<UserConversation> UsersConversations { get; set; } = new HashSet<UserConversation>();
    }
}