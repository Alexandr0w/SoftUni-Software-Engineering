﻿using System.ComponentModel.DataAnnotations;
using Cadastre.Data.Enumerations;
using static Cadastre.Common.ValidationConstants;

namespace Cadastre.Data.Models
{
    public class Citizen
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(CitizenNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(CitizenNameMaxLength)]
        public string LastName { get; set; } = null!;

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public MaritalStatus MaritalStatus { get; set; }

        public virtual ICollection<PropertyCitizen> PropertiesCitizens { get; set; } = new HashSet<PropertyCitizen>();
    }
}