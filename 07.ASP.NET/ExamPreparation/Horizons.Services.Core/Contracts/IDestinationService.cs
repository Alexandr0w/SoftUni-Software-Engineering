namespace Horizons.Services.Core.Contracts
{
    using Web.ViewModels.Destination;

    public interface IDestinationService
    {
        Task<IEnumerable<DestinationIndexViewModel>> GetAllDestinationsAsync(string? userId);

        Task<DestinationDetailsViewModel> GetDestinationDetailsAsync(int? id, string? userId);

        Task<bool> AddDestinationAsync(string userId, AddDestinationInputModel inputModel);

        Task<EditDestinationInputModel?> GetDestinationForEditingAsync(string userId, int? destId);

        Task<bool> PersistUpdatedDestinationAsync(string userId, EditDestinationInputModel inputModel);

        Task<DeleteDestinationInputModel?> GetDestinationForDeletingAsync(string userId, int? destId);

        Task<bool> SoftDeleteDestinationAsync(string userId, DeleteDestinationInputModel inputModel);

        Task<IEnumerable<FavoriteDestinationViewModel>?> GetFavoriteDestinationsAsync(string userId);

        Task<bool> AddDestinationToUserFavoritesListAsync(string userId, int destId);

        Task<bool> RemoveDestinationFromUserFavoritesListAsync(string userId, int destId);
    }
}
