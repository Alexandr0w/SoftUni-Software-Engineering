﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medicines.Data.Models
{
    public class PatientMedicine
    {
        [Required]
        [ForeignKey(nameof(Patient))]
        public int PatientId { get; set; }
        public Patient Patient { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Medicine))]
        public int MedicineId { get; set; }
        public Medicine Medicine { get; set; } = null!;
    }
}

