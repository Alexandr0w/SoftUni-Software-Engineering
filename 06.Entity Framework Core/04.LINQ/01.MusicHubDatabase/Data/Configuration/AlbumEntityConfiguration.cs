namespace MusicHub.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using static Data.EntityValidationConstants.Album;
    using Models;
    public class AlbumEntityConfiguration : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> entity)
        {
            // Define primary key <=> [Key]
            entity.HasKey(a => a.Id);

            entity.Property(a => a.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(AlbumNameMaxLength);

            entity.Property(a => a.ReleaseDate)
                .IsRequired();

            entity.Property(a => a.ProducerId)
                .IsRequired(false);

            entity.HasOne(a => a.Producer)
                .WithMany(p => p.Albums)
                .HasForeignKey(a => a.ProducerId);
        }
    }
}
