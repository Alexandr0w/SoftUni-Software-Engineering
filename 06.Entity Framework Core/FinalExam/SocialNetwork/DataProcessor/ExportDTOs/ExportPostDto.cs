using System.Xml.Serialization;
using SocialNetwork.Data.Models;

namespace SocialNetwork.DataProcessor.ExportDTOs
{
    [XmlType(nameof(Post))]
    public class ExportPostDto
    {
        [XmlElement(nameof(Content))]
        public string Content { get; set; } = null!;

        [XmlElement(nameof(CreatedAt))]
        public string CreatedAt { get; set; } = null!;
    }
}
