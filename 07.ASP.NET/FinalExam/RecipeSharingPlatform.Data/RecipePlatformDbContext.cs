using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using RecipeSharingPlatform.Data.Models;

namespace RecipeSharingPlatform.Data
{
    public class RecipePlatformDbContext : IdentityDbContext
    {
        public RecipePlatformDbContext(DbContextOptions<RecipePlatformDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Recipe> Recipes { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<UserRecipe> UsersRecipes { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}