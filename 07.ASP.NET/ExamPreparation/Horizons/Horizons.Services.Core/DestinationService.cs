namespace Horizons.Services.Core
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Globalization;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity;
    using Data;
    using Data.Models;
    using static GCommon.ValidationConstants.Destination;
    using Services.Core.Contracts;
    using Web.ViewModels.Destination;

    public class DestinationService : IDestinationService
    {
        private readonly HorizonsDbContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;

        public DestinationService(HorizonsDbContext dbContext, UserManager<IdentityUser> userManager)
        {
            this._dbContext = dbContext;
            this._userManager = userManager;
        }

        public async Task<IEnumerable<DestinationIndexViewModel>> GetAllDestinationsAsync(string? userId)
        {
            IEnumerable<DestinationIndexViewModel> allDestinations = await this._dbContext
                .Destinations
                .Include(d => d.Terrain)
                .Include(d => d.UsersDestinations)
                .AsNoTracking()
                .Select(d => new DestinationIndexViewModel()
                {
                    Id = d.Id,
                    Name = d.Name,
                    ImageUrl = d.ImageUrl,
                    TerrainName = d.Terrain.Name,
                    FavoritesCount = d.UsersDestinations.Count,
                    IsUserPublisher = userId != null ?
                        d.PublisherId.ToLower() == userId.ToLower() : false,
                    IsInUserFavorite = userId != null ?
                        d.UsersDestinations.Any(ud => ud.UserId.ToLower() == userId.ToLower()) : false,
                })
                .ToArrayAsync();

                return allDestinations;
        }

        public async Task<DestinationDetailsViewModel> GetDestinationDetailsAsync(int? id, string? userId)
        {
            DestinationDetailsViewModel? detailsVm = null;

            if (id.HasValue)
            {
                Destination? destinationModel = await this._dbContext
                    .Destinations
                    .Include(d => d.Terrain)
                    .Include(d => d.Publisher)
                    .Include(d => d.UsersDestinations)
                    .AsNoTracking()
                    .SingleOrDefaultAsync(d => d.Id == id.Value);

                if (destinationModel != null)
                {
                    detailsVm = new DestinationDetailsViewModel()
                    {
                        Id = destinationModel.Id,
                        Name = destinationModel.Name,
                        ImageUrl = destinationModel.ImageUrl,
                        Description = destinationModel.Description,
                        PublishedOn = destinationModel.PublishedOn.ToString(PublishedOnFormat),
                        TerrainName = destinationModel.Terrain.Name,
                        PublisherName = destinationModel.Publisher.UserName,
                        IsUserPublisher = userId != null ?
                            destinationModel.PublisherId.ToLower() == userId.ToLower() : false,
                        IsInUserFavorite = userId != null ?
                            destinationModel.UsersDestinations.Any(ud => ud.UserId.ToLower() == userId.ToLower()) : false,
                    };
                }
            }

            return detailsVm!;
        }

        public async Task<bool> AddDestinationAsync(string userId, AddDestinationInputModel inputModel)
        {
            bool opResult = false;

            IdentityUser? user = await this._userManager.FindByIdAsync(userId);
            Terrain? terrainRef = await this._dbContext
                .Terrains
                .FindAsync(inputModel.TerrainId);

            bool isPublishedOnDateValid = DateTime
                .TryParseExact(inputModel.PublishedOn, PublishedOnFormat, CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out DateTime publishedOnDate);

            if (user != null && terrainRef != null && isPublishedOnDateValid)
            {
                Destination newDestination = new Destination()
                {
                    Name = inputModel.Name,
                    Description = inputModel.Description,
                    ImageUrl = inputModel.ImageUrl,
                    PublishedOn = publishedOnDate,
                    PublisherId = userId,
                    TerrainId = inputModel.TerrainId,
                };

                await this._dbContext.Destinations.AddAsync(newDestination);
                await this._dbContext.SaveChangesAsync();

                opResult = true;
            }

            return opResult;
        }

        public async Task<EditDestinationInputModel?> GetDestinationForEditingAsync(string userId, int? destId)
        {
            EditDestinationInputModel? editModel = null;

            if (destId != null)
            {
                Destination? editDestinationModel = await this._dbContext
                    .Destinations
                    .AsNoTracking()
                    .SingleOrDefaultAsync(d => d.Id == destId);

                if (editDestinationModel != null &&
                    editDestinationModel.PublisherId.ToLower() == userId.ToLower())
                {
                    editModel = new EditDestinationInputModel()
                    {
                        Id = editDestinationModel.Id,
                        Name = editDestinationModel.Name,
                        Description = editDestinationModel.Description,
                        ImageUrl = editDestinationModel.ImageUrl,
                        TerrainId = editDestinationModel.TerrainId,
                        PublishedOn = editDestinationModel.PublishedOn.ToString(PublishedOnFormat),
                        PublisherId = editDestinationModel.PublisherId,
                    };
                }
            }

            return editModel;
        }

        public async Task<bool> PersistUpdatedDestinationAsync(string userId, EditDestinationInputModel inputModel)
        {
            bool opResult = false;

            IdentityUser? user = await this._userManager.FindByIdAsync(userId);

            Destination? updatedDest = await this._dbContext
                .Destinations
                .FindAsync(inputModel.Id);

            Terrain? terrainRef = await this._dbContext
                .Terrains
                .FindAsync(inputModel.TerrainId);

            bool isPublishedOnDateValid = DateTime
                .TryParseExact(inputModel.PublishedOn, PublishedOnFormat, CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out DateTime publishedOnDate);

            if (user != null && terrainRef != null && updatedDest != null 
                && isPublishedOnDateValid && updatedDest.PublisherId.ToLower() == userId.ToLower())
            {
                updatedDest.Name = inputModel.Name;
                updatedDest.Description = inputModel.Description;
                updatedDest.PublishedOn = publishedOnDate;
                updatedDest.ImageUrl = inputModel.ImageUrl;
                updatedDest.TerrainId = inputModel.TerrainId;

                await this._dbContext.SaveChangesAsync();

                opResult = true;
            }

            return opResult;
        }

        public async Task<DeleteDestinationInputModel?> GetDestinationForDeletingAsync(string userId, int? destId)
        {
            DeleteDestinationInputModel? deleteModel = null;

            if (destId != null)
            {
                Destination? deleteDestinationModel = await this._dbContext
                    .Destinations
                    .Include(d => d.Publisher)
                    .AsNoTracking()
                    .SingleOrDefaultAsync(d => d.Id == destId);

                if (deleteDestinationModel != null &&
                    deleteDestinationModel.PublisherId.ToLower() == userId.ToLower())
                {
                    deleteModel = new DeleteDestinationInputModel()
                    {
                        Id = deleteDestinationModel.Id,
                        Name = deleteDestinationModel.Name,
                        Publisher = deleteDestinationModel.Publisher.NormalizedUserName,
                        PublisherId = deleteDestinationModel.PublisherId
                    };
                }
            }

            return deleteModel;
        }

        public async Task<bool> SoftDeleteDestinationAsync(string userId, DeleteDestinationInputModel inputModel)
        {
            bool opResult = false;

            IdentityUser? user = await this._userManager.FindByIdAsync(userId);

            Destination? deletedDest = await this._dbContext
                .Destinations
                .FindAsync(inputModel.Id);

            if (user != null && deletedDest != null && 
                deletedDest.PublisherId.ToLower() == userId.ToLower())
            {
                deletedDest.IsDeleted = true; 

                await this._dbContext.SaveChangesAsync();

                opResult = true;
            }

            return opResult;
        }

        public async Task<IEnumerable<FavoriteDestinationViewModel>?> GetFavoriteDestinationsAsync(string userId)
        {
            IEnumerable<FavoriteDestinationViewModel>? favDestinations = null;

            IdentityUser? user = await this._userManager.FindByIdAsync(userId);

            if (user != null)
            {
                favDestinations = await this._dbContext
                    .UsersDestinations
                    .Include(ud => ud.Destination)
                    .ThenInclude(d => d.Terrain)
                    .Where(ud => ud.UserId.ToLower() == userId.ToLower())
                    .Select(ud => new FavoriteDestinationViewModel()
                    {
                        Id = ud.DestinationId,
                        Name = ud.Destination.Name,
                        ImageUrl = ud.Destination.ImageUrl,
                        Terrain = ud.Destination.Terrain.Name
                    })
                    .ToArrayAsync();
            }

            return favDestinations;
        }

        public async Task<bool> AddDestinationToUserFavoritesListAsync(string userId, int destId)
        {
            bool opResult = false;

            IdentityUser? user = await this._userManager.FindByIdAsync(userId);

            Destination? favDestination = await this._dbContext
                .Destinations
                .FindAsync(destId);

            if (user != null && favDestination != null &&
                favDestination.PublisherId.ToLower() != userId.ToLower())
            {
                UserDestination? userFavDest = await this._dbContext
                    .UsersDestinations
                    .SingleOrDefaultAsync(ud => ud.UserId.ToLower() == userId && ud.DestinationId == destId);

                if (userFavDest == null)
                {
                    userFavDest = new UserDestination()
                    {
                        UserId = userId,
                        DestinationId = destId
                    };

                    await this._dbContext.UsersDestinations.AddAsync(userFavDest);
                    await this._dbContext.SaveChangesAsync();

                    opResult = true;
                }
            }

            return opResult;
        }

        public async Task<bool> RemoveDestinationFromUserFavoritesListAsync(string userId, int destId)
        {
            bool opResult = false;

            IdentityUser? user = await this._userManager.FindByIdAsync(userId);

            if (user != null)
            {
                UserDestination? userFavDest = await this._dbContext
                    .UsersDestinations
                    .SingleOrDefaultAsync(ud => ud.UserId.ToLower() == userId.ToLower() && ud.DestinationId == destId);

                if (userFavDest != null)
                {
                    this._dbContext.UsersDestinations.Remove(userFavDest);
                    await this._dbContext.SaveChangesAsync();

                    opResult = true;
                }
            }

            return opResult;
        }
    }
}
