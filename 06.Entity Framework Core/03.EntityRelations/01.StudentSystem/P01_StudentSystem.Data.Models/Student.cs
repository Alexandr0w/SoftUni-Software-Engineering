namespace P01_StudentSystem.Data.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationConstants.Student;

    public class Student
    {
        [Key]  
        public int StudentId { get; set; }

        [Required]
        [MaxLength(StudentNameMaxLength)]
        [Unicode(true)]
        public string Name { get; set; } = null!;

        [Unicode(false)]
        public string? PhoneNumber { get; set; }

        [Required]
        public DateTime RegisteredOn { get; set; }

        public DateTime? Birthday { get; set; }

        public ICollection<Homework> Homeworks { get; set; } = new HashSet<Homework>();
        public ICollection<StudentCourse> StudentsCourses { get; set; } = new HashSet<StudentCourse>();
    }
}
