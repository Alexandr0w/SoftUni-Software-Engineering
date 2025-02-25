namespace MusicHub.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using static Data.EntityValidationConstants.Performer;
    using Models;

    public class PerformerEntityConfiguration : IEntityTypeConfiguration<Performer>
    {
        public void Configure(EntityTypeBuilder<Performer> entity)
        {
            entity.HasKey(p => p.Id);

            entity.Property(p => p.FirstName)
                .HasMaxLength(PerformerFirstNameMaxLength)
                .IsRequired()
                .IsUnicode();

            entity.Property(p => p.LastName)
                .HasMaxLength(PerformerLastNameMaxLength)
                .IsRequired()
                .IsUnicode();

            entity.Property(p => p.Age)
                .IsRequired();

            entity.Property(p => p.NetWorth)
                .IsRequired();
        }
    }
}
