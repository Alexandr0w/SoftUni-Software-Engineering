namespace MusicHub.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using static EntityValidationConstants.Writer;
    using Models;

    public class WriterEntityConfiguration : IEntityTypeConfiguration<Writer>
    {
        public void Configure(EntityTypeBuilder<Writer> entity)
        {
            entity.HasKey(w => w.Id);

            entity.Property(w => w.Name)
                .HasMaxLength(WriterNameMaxLength)
                .IsRequired()
                .IsUnicode();

            entity.Property(w => w.Pseudonym)
                .IsRequired(false)
                .IsUnicode();
        }
    }
}
