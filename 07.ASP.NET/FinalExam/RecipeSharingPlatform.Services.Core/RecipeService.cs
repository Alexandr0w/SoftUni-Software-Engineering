using System.Globalization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RecipeSharingPlatform.Data;
using RecipeSharingPlatform.Data.Models;
using RecipeSharingPlatform.Services.Core.Contracts;
using RecipeSharingPlatform.ViewModels.Recipe;
using static RecipeSharingPlatform.GCommon.ValidationConstants.Recipe;

namespace RecipeSharingPlatform.Services.Core
{
    public class RecipeService : IRecipeService
    {
        private readonly RecipePlatformDbContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;
        public RecipeService(RecipePlatformDbContext applicationDbContext, UserManager<IdentityUser> userManager)
        {
            this._dbContext = applicationDbContext;
            this._userManager = userManager;
        }

        public async Task<IEnumerable<RecipeIndexViewModel>> GetAllRecipesAsync(string? userId)
        {
            IEnumerable<RecipeIndexViewModel> recipes = await this._dbContext
                .Recipes
                  .Include(r => r.Category)
                  .Include(r => r.UsersRecipes)
                  .AsNoTracking()
                  .Select(r => new RecipeIndexViewModel()
                  {
                      Id = r.Id,
                      Title = r.Title,
                      ImageUrl = r.ImageUrl,
                      Category = r.Category.Name,
                      SavedCount = r.UsersRecipes.Count(),
                      IsAuthor = userId != null ? r.AuthorId.ToLower() == userId.ToLower() : false,
                      IsSaved = userId != null ? r.UsersRecipes.Any(ur => ur.UserId.ToLower() == userId.ToLower()) : false

                  })
                .ToArrayAsync();

            return recipes;
        }

        public async Task<bool> CreateRecipeAsync(string? userId, CreateRecipeInputModel inputModel)
        {
            bool opResult = false;
            IdentityUser? user = await this._userManager.FindByIdAsync(userId);
            Category? category = await this._dbContext.Categories.FindAsync(inputModel.CategoryId);

            bool isCreatedOnValid = DateTime.TryParseExact(inputModel.CreatedOn, CreatedOnFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime createdOn);

            if (user != null && category != null && isCreatedOnValid)
            {
                Recipe Newrecipe = new Recipe()
                {
                    Title = inputModel.Title,
                    Instructions = inputModel.Instructions,
                    ImageUrl = inputModel.ImageUrl,
                    AuthorId = user.Id,
                    Author = user,
                    CreatedOn = createdOn,
                    CategoryId = category.Id,
                    Category = category
                };
                await this._dbContext.Recipes.AddAsync(Newrecipe);
                await this._dbContext.SaveChangesAsync();

                opResult = true;
            }

            return opResult;
        }

        public async Task<DeleteRecipeInputModel> GetRecipeForDeletingAsync(string? userId, int id)
        {
            DeleteRecipeInputModel? deleteModel = null;

            if (id != null)
            {
                Recipe? DeleteRecipeModel = await this._dbContext
                    .Recipes
                    .Include(r => r.Author)
                   .AsNoTracking()
                   .SingleOrDefaultAsync(r => r.Id == id);

                if (DeleteRecipeModel != null && DeleteRecipeModel.AuthorId.ToLower() == userId.ToLower())
                {
                    deleteModel = new DeleteRecipeInputModel()
                    {
                        Id = DeleteRecipeModel.Id,
                        Title = DeleteRecipeModel.Title,
                        Author = DeleteRecipeModel.Author.UserName,
                        AuthorId = DeleteRecipeModel.AuthorId
                    };
                }
            }

            return deleteModel!;
        }

        public async Task<bool> SoftDeleteDestinationAsync(string userId, DeleteRecipeInputModel inputModel)
        {
            bool opResult = false;

            IdentityUser? user = await this._userManager.FindByIdAsync(userId);

            Recipe? recipe = await this._dbContext
                .Recipes.FindAsync(inputModel.Id);

            if (user != null && recipe != null && recipe.AuthorId.ToLower() == userId.ToLower())
            {
                recipe.IsDeleted = true;

                await this._dbContext.SaveChangesAsync();
                opResult = true;
            }

            return opResult;
        }

        public async Task<DetailsRecipeViewModel> GetRecipeDetailsAsync(string userId, int? id)
        {
            DetailsRecipeViewModel? detailsRecipeVm = null;

            if (id.HasValue)
            {
                Recipe? recipe = await this._dbContext.Recipes
                    .Include(r => r.Category)
                    .Include(r => r.UsersRecipes)
                    .Include(r => r.Author)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(r => r.Id == id.Value);

                if (recipe != null)
                {
                    detailsRecipeVm = new DetailsRecipeViewModel()
                    {
                        Id = recipe.Id,
                        Title = recipe.Title,
                        ImageUrl = recipe.ImageUrl,
                        Category = recipe.Category.Name,
                        IsAuthor = userId != null ? recipe.AuthorId.ToLower() == userId.ToLower() : false,
                        IsSaved = recipe.UsersRecipes.Any(ur => userId != null ? ur.UserId.ToLower() == userId.ToLower() : false),
                        Instructions = recipe.Instructions,
                        CreatedOn = recipe.CreatedOn.ToString(CreatedOnFormat, CultureInfo.InvariantCulture),
                        Author = recipe.Author.UserName!
                    };

                }
            }

            return detailsRecipeVm!;
        }

        public async Task<EditRecipeInputModel> GetRecipeForEditingAsync(string userId, int? id)
        {
            EditRecipeInputModel? editModel = null;

            if (id != null)
            {
                Recipe? recipeToEdit = await this._dbContext.Recipes
                .AsNoTracking()
                .SingleOrDefaultAsync(r => r.Id == id);

                if (recipeToEdit != null && recipeToEdit.AuthorId.ToLower() == userId.ToLower())
                {
                    editModel = new EditRecipeInputModel()
                    {
                        Id = recipeToEdit.Id,
                        Title = recipeToEdit.Title,
                        Instructions = recipeToEdit.Instructions,
                        ImageUrl = recipeToEdit.ImageUrl,
                        CreatedOn = recipeToEdit.CreatedOn.ToString(CreatedOnFormat, CultureInfo.InvariantCulture),
                        CategoryId = recipeToEdit.CategoryId,
                        Categories = await this._dbContext.Categories
                            .Select(c => new AddCategoryDropDownModel()
                            {
                                Id = c.Id,
                                Name = c.Name
                            })
                            .ToListAsync()
                    };
                }

            }

            return editModel!;
        }

        public async Task<bool> PersistUpdatedRecipeAsync(string userId, EditRecipeInputModel inputModel)
        {
            bool opResult = false;
            IdentityUser? user = await this._userManager.FindByIdAsync(userId);

            Recipe? updatedRecipe = await this._dbContext
                .Recipes
                .FindAsync(inputModel.Id);

            Category? categoryRef = await this._dbContext
             .Categories
             .FindAsync(inputModel.CategoryId);

            bool isPublishedOnDateValid = DateTime
                   .TryParseExact(inputModel.CreatedOn, CreatedOnFormat, CultureInfo.InvariantCulture,
                       DateTimeStyles.None, out DateTime publishedOnDate);

            if (user != null && categoryRef != null && updatedRecipe != null
                && isPublishedOnDateValid && updatedRecipe.AuthorId.ToLower() == userId.ToLower())
            {
                updatedRecipe.Title = inputModel.Title;
                updatedRecipe.Instructions = inputModel.Instructions;
                updatedRecipe.ImageUrl = inputModel.ImageUrl;
                updatedRecipe.CategoryId = categoryRef.Id;
                updatedRecipe.Category = categoryRef;
                updatedRecipe.CreatedOn = publishedOnDate;

                await this._dbContext.SaveChangesAsync();
                opResult = true;
            }

            return opResult;
        }

        public async Task<IEnumerable<FavoriteRecipeViewModel>> GetFavoriteRecipesAsync(string userId)
        {
            IEnumerable<FavoriteRecipeViewModel>? favRecipes = null;
            IdentityUser? user = await this._userManager.FindByIdAsync(userId);

            if (user != null)
            {
                favRecipes = await this._dbContext
                    .UsersRecipes
                    .Include(ur => ur.Recipe)
                    .ThenInclude(ur => ur.Category)
                    .AsNoTracking()
                     .Where(ur => ur.UserId.ToLower() == userId.ToLower())
                    .Select(ur => new FavoriteRecipeViewModel()
                    {
                        Id = ur.Recipe.Id,
                        Title = ur.Recipe.Title,
                        ImageUrl = ur.Recipe.ImageUrl,
                        Category = ur.Recipe.Category.Name


                    })
                    .ToArrayAsync();
            }
            return favRecipes!;
        }

        public async Task<bool> AddRecipeToUserFavoritesListAsync(string userId, int id)
        {
            bool opResult = false;

            IdentityUser? user = await this._userManager.FindByIdAsync(userId);

            Recipe? favRecipe = await this._dbContext
                .Recipes
                .FindAsync(id);

            if (user != null && favRecipe != null &&
                favRecipe.AuthorId.ToLower() != userId.ToLower())
            {
                UserRecipe? userFavRecipe = await this._dbContext
                    .UsersRecipes
                    .SingleOrDefaultAsync(ud => ud.UserId.ToLower() == userId && ud.RecipeId == id);

                if (userFavRecipe == null)
                {
                    userFavRecipe = new UserRecipe()
                    {
                        UserId = userId,
                        RecipeId = id
                    };

                    await this._dbContext.UsersRecipes.AddAsync(userFavRecipe);
                    await this._dbContext.SaveChangesAsync();

                    opResult = true;
                }
            }

            return opResult;
        }

        public async Task<bool> RemoveRecipeFromUserFavoritesListAsync(string userId, int id)
        {
            bool opResult = false;

            IdentityUser? user = await this._userManager.FindByIdAsync(userId);

            if (user != null)
            {
                UserRecipe? userFavRecipe = await this._dbContext
                    .UsersRecipes
                    .SingleOrDefaultAsync(ud => ud.UserId.ToLower() == userId.ToLower() && ud.RecipeId == id);

                if (userFavRecipe != null)
                {
                    this._dbContext.UsersRecipes.Remove(userFavRecipe);
                    await this._dbContext.SaveChangesAsync();

                    opResult = true;
                }
            }

            return opResult;
        }
    }
}







