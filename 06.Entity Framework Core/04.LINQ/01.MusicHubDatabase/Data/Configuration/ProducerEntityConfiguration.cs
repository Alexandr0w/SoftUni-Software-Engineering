namespace MusicHub.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using static Data.EntityValidationConstants.Producer;
    using Models;

    public class ProducerEntityConfiguration : IEntityTypeConfiguration<Producer>
    {
        public void Configure(EntityTypeBuilder<Producer> entity)
        {
            entity.HasKey(p => p.Id);

            entity.Property(p => p.Name)
                .HasMaxLength(ProducerNameMaxLength)
                .IsRequired()
                .IsUnicode();

            entity.Property(p => p.Pseudonym)
                .IsRequired(false)
                .IsUnicode();

            entity.Property(p => p.PhoneNumber)
                .IsRequired(false)
                .IsUnicode();
        }
    }
}
