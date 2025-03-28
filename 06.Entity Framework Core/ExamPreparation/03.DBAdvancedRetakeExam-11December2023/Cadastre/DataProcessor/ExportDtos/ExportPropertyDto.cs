using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Cadastre.Data.Models;
using static Cadastre.Common.ValidationConstants;

namespace Cadastre.DataProcessor.ExportDtos
{
    [XmlType(nameof(Property))]
    public class ExportPropertyDto
    {
        [XmlAttribute("postal-code")]
        public string PostalCode { get; set; } = null!;

        [XmlElement(nameof(PropertyIdentifier))]
        public string PropertyIdentifier { get; set; } = null!;

        [XmlElement(nameof(Area))]
        public int Area { get; set; }

        [XmlElement(nameof(DateOfAcquisition))]
        public string DateOfAcquisition { get; set; } = null!;
    }
}
