namespace GameZone.Services.Contracts
{
    using Models;
    using Data.Models;
    public interface IGameService
    {
        Task<IEnumerable<GameInfoViewModel>> GetAllAsync();
        Task AddGameAsync(GameViewModel game, string userId);

        Task AddGameToMyZoneAsync(string userId, Game game);


        Task<IEnumerable<GameInfoViewModel>> GetMyZоneAsync(string userId);
        Task<GameViewModel> GetAddModelAsync();
        Task<Game?> GetGameByIdAsync(int id);
        Task<GameViewModel?> GetEditModelAsync(int id);
        Task EditGameAsync(GameViewModel model, Game game);
        Task StrikeOutAsync(string userId, Game game);
        Task<GameDetailsViewModel?> GetGameDetails(int id);
        Task<GameDeleteViewModel?> GetGameForDeleteAsync(int id);
        Task SoftDeleteGameAsync(GameDeleteViewModel model);
    }
}
