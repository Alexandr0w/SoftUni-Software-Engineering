using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace TravelAgency.DataProcessor.ExportDtos
{
    public class ExportBookingDto
    {
        [Required]
        [JsonProperty(nameof(TourPackageName))]
        public string TourPackageName { get; set; } = null!;

        [Required]
        [JsonProperty(nameof(Date))]
        public string Date { get; set; } = null!;
    }
}
