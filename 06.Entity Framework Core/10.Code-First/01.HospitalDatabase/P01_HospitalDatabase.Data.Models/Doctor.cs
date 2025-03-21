using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static P01_HospitalDatabase.Common.ValidationConstants.Doctor;

namespace P01_HospitalDatabase.Data.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }

        [Required]
        [Unicode(true)]
        [MaxLength(DoctorNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [Unicode(true)]
        [MaxLength(DoctorSpecialtyMaxLength)]
        public string Specialty { get; set; } = null!;

        [Required]
        [MaxLength(DoctorEmailMaxLength)]
        public string Email { get; set; } = null!;

        [Required]
        [MaxLength(DoctorPasswordMaxLength)]
        public string Password { get; set; } = null!;

        public virtual ICollection<Visitation> Visitations { get; set; } = new HashSet<Visitation>();
    }
}