using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace TravelAgency.DataProcessor.ExportDtos
{
    public class ExportCustomerDto
    {
        [Required]
        [JsonProperty(nameof(FullName))]
        public string FullName { get; set; } = null!;

        [Required]
        [JsonProperty(nameof(PhoneNumber))]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [JsonProperty(nameof(Bookings))]
        public ExportBookingDto[] Bookings { get; set; } = null!;
    }
}
