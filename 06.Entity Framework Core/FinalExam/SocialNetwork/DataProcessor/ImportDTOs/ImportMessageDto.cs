using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using SocialNetwork.Data.Enums;
using SocialNetwork.Data.Models;
using static SocialNetwork.Common.ValidationConstants;

namespace SocialNetwork.DataProcessor.ImportDTOs
{
    [XmlType(nameof(Message))]
    public class ImportMessageDto
    {
        [Required]
        [XmlAttribute(nameof(SentAt))]
        public string SentAt { get; set; } = null!;

        [Required]
        [XmlElement(nameof(Content))]
        [StringLength(MessageContentMaxLength, MinimumLength = MessageContentMinLength)]
        public string Content { get; set; } = null!;

        [Required]
        [XmlElement(nameof(Status))]
        [EnumDataType(typeof(MessageStatus))]
        public string Status { get; set; } = null!;

        [Required]
        [XmlElement(nameof(ConversationId))]
        public int ConversationId { get; set; }

        [Required]
        [XmlElement(nameof(SenderId))]
        public int SenderId { get; set; }
    }
}
