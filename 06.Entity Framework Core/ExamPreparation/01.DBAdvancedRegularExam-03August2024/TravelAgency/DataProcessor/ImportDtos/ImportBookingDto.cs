using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace TravelAgency.DataProcessor.ImportDtos
{
    public class ImportBookingDto
    {
        [Required]
        [JsonProperty(nameof(BookingDate))]
        public string BookingDate { get; set; } = null!;

        [Required]
        [JsonProperty(nameof(CustomerName))]
        public string CustomerName { get; set; } = null!;

        [Required]
        [JsonProperty(nameof(TourPackageName))]
        public string TourPackageName { get; set; } = null!;
    }
}
