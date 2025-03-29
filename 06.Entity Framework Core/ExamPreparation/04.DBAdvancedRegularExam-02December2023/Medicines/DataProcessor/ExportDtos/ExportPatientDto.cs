using Medicines.Data.Models;
using System.ComponentModel;
using System.Xml.Serialization;

namespace Medicines.DataProcessor.ExportDtos
{
    [XmlType(nameof(Patient))]
    public class ExportPatientDto
    {
        [XmlAttribute(nameof(Gender))]
        public string Gender { get; set; } = null!;

        [XmlElement(nameof(Name))]
        public string Name { get; set; } = null!;

        [XmlElement(nameof(AgeGroup))]
        public string AgeGroup { get; set; } = null!;

        [XmlArray(nameof(Medicines))]
        [XmlArrayItem(nameof(Medicine))]
        public ExportMedicineDto[] Medicines { get; set; } = null!;
    }
}
