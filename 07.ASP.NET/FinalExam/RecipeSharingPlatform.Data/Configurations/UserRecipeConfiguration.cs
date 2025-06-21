using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeSharingPlatform.Data.Models;

namespace RecipeSharingPlatform.Data.Configurations
{
    public class UserRecipeConfiguration : IEntityTypeConfiguration<UserRecipe>
    {
        public void Configure(EntityTypeBuilder<UserRecipe> entity)
        {
            entity
                .HasKey(ur => new { ur.UserId, ur.RecipeId });

            entity
                .HasOne(ur => ur.User)
                .WithMany()
                .HasForeignKey(ur => ur.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            entity
                .HasOne(ur => ur.Recipe)
                .WithMany(r => r.UsersRecipes)
                .HasForeignKey(ur => ur.RecipeId)
                .OnDelete(DeleteBehavior.NoAction);

            entity
                .HasQueryFilter(ud => ud.Recipe.IsDeleted == false);
        }
    }
}
