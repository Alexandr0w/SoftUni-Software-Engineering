using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Cadastre.Data.Enumerations;
using static Cadastre.Common.ValidationConstants;

namespace Cadastre.DataProcessor.ImportDtos
{
    public class ImportCitizenDto
    {
        [Required]
        [JsonProperty(nameof(FirstName))]
        [StringLength(CitizenNameMaxLength, MinimumLength = CitizenNameMinLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [JsonProperty(nameof(LastName))]
        [StringLength(CitizenNameMaxLength, MinimumLength = CitizenNameMinLength)]
        public string LastName { get; set; } = null!;

        [Required]
        [JsonProperty(nameof(BirthDate))]
        public string BirthDate { get; set; } = null!;

        [Required]
        [JsonProperty(nameof(MaritalStatus))]
        [EnumDataType(typeof(MaritalStatus))]
        public string MaritalStatus { get; set; } = null!;

        [Required]
        [JsonProperty(nameof(Properties))]
        public int[] Properties { get; set; } = null!;
    }
}
