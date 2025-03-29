using static Medicines.Common.ValidationConstants;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Medicines.DataProcessor.ImportDtos
{
    public class ImportPatientDto
    {
        [Required]
        [JsonProperty(nameof(FullName))]
        [StringLength(PatientFullNameMaxLength, MinimumLength = PatientFullNameMinLength)]
        public string FullName { get; set; } = null!;

        [Required]
        [JsonProperty(nameof(AgeGroup))]
        [Range(PatientAgeGroupMinValue, PatientAgeGroupMaxValue)]
        public int AgeGroup { get; set; }

        [Required]
        [JsonProperty(nameof(Gender))]
        [Range(PatientGenderMinValue, PatientGenderMaxValue)]
        public int Gender { get; set; }

        [Required]
        [JsonProperty(nameof(Medicines))]
        public int[] Medicines { get; set; } = null!;
    }
}