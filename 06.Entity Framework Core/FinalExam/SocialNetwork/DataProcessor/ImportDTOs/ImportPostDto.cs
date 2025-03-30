using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using static SocialNetwork.Common.ValidationConstants;

namespace SocialNetwork.DataProcessor.ImportDTOs
{
    public class ImportPostDto
    {
        [Required]
        [JsonProperty(nameof(Content))]
        [StringLength(PostContentMaxLength, MinimumLength = PostContentMinLength)]
        public string Content { get; set; } = null!;

        [Required]
        [JsonProperty(nameof(CreatedAt))]
        public string CreatedAt { get; set; } = null!;

        [Required]
        [JsonProperty(nameof(CreatorId))]
        public int CreatorId { get; set; }
    }
}
