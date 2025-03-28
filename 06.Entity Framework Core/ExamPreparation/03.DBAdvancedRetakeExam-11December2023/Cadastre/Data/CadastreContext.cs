using Microsoft.EntityFrameworkCore;
using Cadastre.Data.Models;

namespace Cadastre.Data
{
    public class CadastreContext : DbContext
    {
        public CadastreContext()
        {

        }

        public CadastreContext(DbContextOptions options)
            : base(options)
        {

        }

        // DbSet here
        public virtual DbSet<Citizen> Citizens { get; set; } = null!;
        public virtual DbSet<District> Districts { get; set; } = null!;
        public virtual DbSet<Property> Properties { get; set; } = null!;
        public virtual DbSet<PropertyCitizen> PropertiesCitizens { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Fluent API here
            modelBuilder.Entity<PropertyCitizen>()
                .HasKey(pc => new { pc.CitizenId, pc.PropertyId });
        }
    }
}
