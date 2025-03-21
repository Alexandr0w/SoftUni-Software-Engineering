using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using static P01_HospitalDatabase.Common.ValidationConstants.Visitation;

namespace P01_HospitalDatabase.Data.Models
{
    public class Visitation
    {
        [Key]
        public int VisitationId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [Unicode(true)]
        [MaxLength(VisitationCommentsMaxLength)]
        public string Comments { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Doctor))]
        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Patient))]
        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; } = null!;

        public virtual ICollection<Doctor> Doctors { get; set; } = new HashSet<Doctor>();
    }
}
