namespace Homies.Data
{
    using Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

    public class HomiesDbContext : IdentityDbContext
    {
        public HomiesDbContext(DbContextOptions<HomiesDbContext> options)
            : base(options)
        {
        }

        public DbSet<Event> Events { get; set; } = null!;
        public DbSet<Type> Types { get; set; } = null!;
        public DbSet<EventParticipant> EventsParticipants { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventParticipant>()
                .HasKey(ep => new { ep.HelperId, ep.EventId });

            modelBuilder.Entity<EventParticipant>()
                .HasOne(ep => ep.Event)
                .WithMany(e => e.EventsParticipants)
                .HasForeignKey(ep => ep.EventId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<EventParticipant>()
                .HasOne(ep => ep.Helper)
                .WithMany()
                .HasForeignKey(ep => ep.HelperId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .Entity<Type>()
                .HasData(new Type()
                {
                    Id = 1,
                    Name = "Animals"
                },
                new Type()
                {
                    Id = 2,
                    Name = "Fun"
                },
                new Type()
                {
                    Id = 3,
                    Name = "Discussion"
                },
                new Type()
                {
                    Id = 4,
                    Name = "Work"
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}