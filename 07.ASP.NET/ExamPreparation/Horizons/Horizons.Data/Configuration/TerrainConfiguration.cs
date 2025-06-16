namespace Horizons.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;
    using static GCommon.ValidationConstants.Terrain;

    public class TerrainConfiguration : IEntityTypeConfiguration<Terrain>
    {
        public void Configure(EntityTypeBuilder<Terrain> entity)
        {
            entity
                .HasKey(t => t.Id);

            entity
                .Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(NameMaxLength);

            entity
                .HasData(this.GenerateSeedTerrains());
        }

        private List<Terrain> GenerateSeedTerrains()
        {
            List<Terrain> seedTerrains = new List<Terrain>()
            {
                new Terrain { Id = 1, Name = "Mountain" },
                new Terrain { Id = 2, Name = "Beach" },
                new Terrain { Id = 3, Name = "Forest" },
                new Terrain { Id = 4, Name = "Plain" },
                new Terrain { Id = 5, Name = "Urban" },
                new Terrain { Id = 6, Name = "Village" },
                new Terrain { Id = 7, Name = "Cave" },
                new Terrain { Id = 8, Name = "Canyon" }
            };

            return seedTerrains;
        }
    }
}
