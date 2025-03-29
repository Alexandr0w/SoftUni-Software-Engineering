using Medicines.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Medicines.Data
{
    public class MedicinesContext : DbContext
    {
        public MedicinesContext()
        {
        }

        public MedicinesContext(DbContextOptions options)
            : base(options)
        {
        }

        // DbSets here
        public virtual DbSet<Medicine> Medicines { get; set; } = null!;
        public virtual DbSet<Patient> Patients { get; set; } = null!;
        public virtual DbSet<PatientMedicine> PatientsMedicines { get; set; } = null!;
        public virtual DbSet<Pharmacy> Pharmacies { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Fluent API here
            modelBuilder.Entity<PatientMedicine>()
                .HasKey(pm => new { pm.PatientId, pm.MedicineId });
        }
    }
}
