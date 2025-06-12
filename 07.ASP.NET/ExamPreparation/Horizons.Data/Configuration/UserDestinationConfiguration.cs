namespace Horizons.Data.Configuration
{
    using Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UserDestinationConfiguration : IEntityTypeConfiguration<UserDestination>
    {
        public void Configure(EntityTypeBuilder<UserDestination> entity)
        {
            entity
                .HasKey(ud => new { ud.UserId, ud.DestinationId });

            // Hide all UserDestination pairs with deleted Destination
            entity
                .HasQueryFilter(ud => ud.Destination.IsDeleted == false);

            entity
                .HasOne(ud => ud.User)
                .WithMany() // Missing navigation collection in the built-in IdentityUser
                .HasForeignKey(ud => ud.UserId);

            entity
                .HasOne(ud => ud.Destination)
                .WithMany(d => d.UsersDestinations)
                .HasForeignKey(ud => ud.DestinationId);
        }
    }
}
