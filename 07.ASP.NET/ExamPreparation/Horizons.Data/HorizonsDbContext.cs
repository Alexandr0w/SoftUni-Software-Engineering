namespace Horizons.Data
{
    using System.Reflection;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Models;

    public class HorizonsDbContext : IdentityDbContext
    {
        public HorizonsDbContext(DbContextOptions<HorizonsDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Destination> Destinations { get; set; } = null!;
        public virtual DbSet<Terrain> Terrains { get; set; } = null!;
        public virtual DbSet<UserDestination> UsersDestinations { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Apply configuration for entities
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
