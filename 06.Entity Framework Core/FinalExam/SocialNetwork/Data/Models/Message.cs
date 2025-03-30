using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SocialNetwork.Data.Enums;
using static SocialNetwork.Common.ValidationConstants;

namespace SocialNetwork.Data.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(MessageContentMaxLength)]
        public string Content { get; set; } = null!;

        [Required]
        public DateTime SentAt { get; set; }

        [Required]
        public MessageStatus Status { get; set; }

        [Required]
        [ForeignKey(nameof(Conversation))]
        public int ConversationId { get; set; }
        public Conversation Conversation { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Sender))]
        public int SenderId { get; set; }
        public User Sender { get; set; } = null!;
    }
}

