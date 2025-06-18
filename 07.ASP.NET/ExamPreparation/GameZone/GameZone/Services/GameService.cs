namespace GameZone.Services
{
    using Data;
    using Models;
    using Contracts;
    using Data.Models;
    using static Common.ValidationConstants.Game;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using System.Globalization;

    public class GameService : IGameService
    {
        private readonly GameZoneDbContext _dbContext;

        public GameService(GameZoneDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<IEnumerable<GameInfoViewModel>> GetAllAsync()
        {
            IEnumerable<GameInfoViewModel> allGames = await this._dbContext
                .Games
                .AsNoTracking()
                .Where(g => g.IsDeleted == false)
                .Select(g => new GameInfoViewModel
                {
                    Id = g.Id,
                    Title = g.Title,
                    ImageUrl = g.ImageUrl,
                    ReleasedOn = g.ReleasedOn.ToString(ReleasedOnFormat),
                    Publisher = g.Publisher.UserName ?? string.Empty,
                    Genre = g.Genre.Name
                })
                .ToArrayAsync();

            return allGames;
        }

        public async Task AddGameAsync(GameViewModel game, string userId)
        {
            bool isValidReleasedOn = DateTime
                .TryParseExact(game.ReleasedOn, ReleasedOnFormat, CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out DateTime releasedOn);

            if (isValidReleasedOn)
            {
                Game gameData = new Game
                {
                    Title = game.Title,
                    Description = game.Description,
                    ImageUrl = game.ImageUrl,
                    PublisherId = userId,
                    ReleasedOn = releasedOn,
                    GenreId = game.GenreId
                };

                await this._dbContext.Games.AddAsync(gameData);
                await this._dbContext.SaveChangesAsync();
            }
        }

        public async Task<GameViewModel> GetAddModelAsync()
        {
            IEnumerable<GenreViewModel> genres = await this._dbContext
                .Genres
                .AsNoTracking()
                .Select(g => new GenreViewModel
                {
                    Id = g.Id,
                    Name = g.Name
                })
                .ToArrayAsync();

            GameViewModel model = new GameViewModel
            {
                Genres = genres
            };

            return model;
        }

        public async Task<GameViewModel?> GetEditModelAsync(int id)
        {
            IEnumerable<GenreViewModel> genres = await this._dbContext
                .Genres
                .AsNoTracking()
                .Select(g => new GenreViewModel
                {
                    Id = g.Id,
                    Name = g.Name
                })
                .ToArrayAsync();

            GameViewModel? game = await this._dbContext
                .Games
                .AsNoTracking()
                .Where(g => g.Id == id)
                .Select(g => new GameViewModel
                {
                    Title = g.Title,
                    Description = g.Description,
                    ImageUrl = g.ImageUrl,
                    ReleasedOn = g.ReleasedOn.ToString(ReleasedOnFormat),
                    GenreId = g.GenreId,
                    Genres = genres
                })
                .FirstOrDefaultAsync();

            return game;
        }

        public async Task EditGameAsync(GameViewModel model, Game game)
        {
            bool isValidReleasedOn = DateTime
                .TryParseExact(model.ReleasedOn, ReleasedOnFormat, CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out DateTime releasedOn);

            if (isValidReleasedOn)
            {
                game.Title = model.Title;
                game.Description = model.Description;
                game.ImageUrl = model.ImageUrl;
                game.ReleasedOn = releasedOn;
                game.GenreId = model.GenreId;

                await this._dbContext.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<GameInfoViewModel>> GetMyZоneAsync(string userId)
        {
            IEnumerable<GameInfoViewModel> myZone = await this._dbContext
                .Games
                .Include(gg => gg.GamersGames)
                .AsNoTracking()
                .Where(g => g.IsDeleted == false)
                .Where(g => g.GamersGames.Any(gg => gg.GamerId == userId))
                .Select(g => new GameInfoViewModel
                {
                    Id = g.Id,
                    Title = g.Title,
                    ImageUrl = g.ImageUrl,
                    ReleasedOn = g.ReleasedOn.ToString(ReleasedOnFormat),
                    Publisher = g.Publisher.UserName ?? string.Empty,
                    Genre = g.Genre.Name
                })
                .ToArrayAsync();

            return myZone;
        }

        public async Task AddGameToMyZoneAsync(string userId, Game game)
        {
            bool isAlreadyAdded = await this._dbContext
                .GamersGames
                .AnyAsync(gg => gg.GamerId == userId && gg.GameId == game.Id);

            if (isAlreadyAdded == true)
            {
                return;
            }

            GamerGame gamerGame = new GamerGame
            {
                GamerId = userId,
                GameId = game.Id
            };

            await this._dbContext.GamersGames.AddAsync(gamerGame);
            await this._dbContext.SaveChangesAsync();
        }

        public async Task StrikeOutAsync(string userId, Game game)
        {
            GamerGame? gamerGame = this._dbContext
                .GamersGames
                .FirstOrDefault(gg => gg.GamerId == userId && gg.GameId == game.Id);

            if (gamerGame != null)
            {
                this._dbContext.GamersGames.Remove(gamerGame);
                await this._dbContext.SaveChangesAsync();
            }
        }

        public async Task<GameDetailsViewModel?> GetGameDetails(int id)
        {
            GameDetailsViewModel? game = await _dbContext
                .Games
                .Where(g => g.Id == id)
                .Select(g => new GameDetailsViewModel
                {
                    Id = g.Id,
                    Title = g.Title,
                    Description = g.Description,
                    ImageUrl = g.ImageUrl,
                    ReleasedOn = g.ReleasedOn.ToString(ReleasedOnFormat),
                    Genre = g.Genre.Name,
                    Publisher = g.Publisher.UserName ?? string.Empty
                })
                .FirstOrDefaultAsync();

            return game;
        }

        public async Task<GameDeleteViewModel?> GetGameForDeleteAsync(int id)
        {
            GameDeleteViewModel? model = await this._dbContext
                .Games
                .AsNoTracking()
                .Where(g => g.Id == id)
                .Select(g => new GameDeleteViewModel
                {
                    Id = g.Id,
                    Title = g.Title,
                    Publisher = g.Publisher.UserName ?? string.Empty
                })
                .FirstOrDefaultAsync();

            return model;
        }

        public Task SoftDeleteGameAsync(Game game)
        {
            throw new NotImplementedException();
        }

        public async Task<Game?> GetGameByIdAsync(int id)
            => await _dbContext
                .Games
                .FirstOrDefaultAsync(g => g.Id == id);
    }
}
