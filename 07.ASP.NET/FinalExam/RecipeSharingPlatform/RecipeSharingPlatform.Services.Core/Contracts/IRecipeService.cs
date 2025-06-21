using RecipeSharingPlatform.ViewModels.Recipe;

namespace RecipeSharingPlatform.Services.Core.Contracts
{
    public interface IRecipeService
    {
        Task<IEnumerable<RecipeIndexViewModel>> GetAllRecipesAsync(string? userId);
        Task<bool> CreateRecipeAsync (string? userId,CreateRecipeInputModel inputModel);

        Task<DetailsRecipeViewModel> GetRecipeDetailsAsync(string userId,int? id);

        Task<DeleteRecipeInputModel> GetRecipeForDeletingAsync(string? userId,int id);
        Task<bool> SoftDeleteDestinationAsync(string userId, DeleteRecipeInputModel inputModel);

        Task<EditRecipeInputModel> GetRecipeForEditingAsync(string userId, int? id); 
        Task<bool> PersistUpdatedRecipeAsync(string userId, EditRecipeInputModel inputModel);

        Task<IEnumerable<FavoriteRecipeViewModel>> GetFavoriteRecipesAsync(string userId);
        Task<bool> AddRecipeToUserFavoritesListAsync(string userId, int id);

        Task<bool> RemoveRecipeFromUserFavoritesListAsync(string userId, int id);
    }
}
