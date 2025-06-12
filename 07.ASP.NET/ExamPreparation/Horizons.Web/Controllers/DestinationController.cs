namespace Horizons.Web.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Services.Core.Contracts;
    using ViewModels.Destination;
    using static GCommon.ValidationConstants.Destination;
    public class DestinationController : BaseController
    {
        private readonly IDestinationService _destinationService;
        private readonly ITerrainService _terrainService;

        public DestinationController(IDestinationService destinationService, ITerrainService terrainService)
        {
            this._destinationService = destinationService;
            this._terrainService = terrainService;  
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            try
            {
                string? userId = this.GetUserId();

                IEnumerable<DestinationIndexViewModel> allDestinations =
                    await this._destinationService.GetAllDestinationsAsync(userId);

                return View(allDestinations);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return this.RedirectToAction(nameof(Index), "Home");
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                string? userId = this.GetUserId();

                DestinationDetailsViewModel destinationDetails = await this._destinationService.GetDestinationDetailsAsync(id, userId);
                
                if (destinationDetails == null)
                {
                    return this.RedirectToAction(nameof(Index));
                }

                return this.View(destinationDetails);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return this.RedirectToAction(nameof(Index), "Home");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            try
            {
                AddDestinationInputModel inputModel = new AddDestinationInputModel()
                {
                    PublishedOn = DateTime.UtcNow.ToString(PublishedOnFormat),
                    Terrains = await this._terrainService.GetTerrainsDropDownAsync(),
                };

                return this.View(inputModel);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return this.RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddDestinationInputModel inputModel)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    return this.View(inputModel);
                }

                bool addResult = await this._destinationService.AddDestinationAsync(this.GetUserId()!, inputModel);

                if (addResult == false)
                {
                    ModelState.AddModelError(string.Empty, "Fatal error occurred while adding a destination!");
                    return this.View(inputModel);
                }

                return this.RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {  
                Console.WriteLine(e.Message);
                return this.RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                string userId = this.GetUserId()!;

                EditDestinationInputModel? editInputModel = await this._destinationService.GetDestinationForEditingAsync(userId, id);

                if (editInputModel == null)
                {
                    return this.RedirectToAction(nameof(Index));
                }

                editInputModel.Terrains = await this._terrainService.GetTerrainsDropDownAsync();

                return this.View(editInputModel);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return this.RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditDestinationInputModel inputModel)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    return this.View(inputModel);
                }

                bool editResult = await this._destinationService.PersistUpdatedDestinationAsync(this.GetUserId()!, inputModel);

                if (editResult == false)
                {
                    this.ModelState.AddModelError(string.Empty, "Fatal error occurred while updating the destination!");
                    return this.View(inputModel);
                }

                return this.RedirectToAction(nameof(Details), new { id = inputModel.Id });

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return this.RedirectToAction(nameof(Index)); 
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                string userId = this.GetUserId()!;

                DeleteDestinationInputModel? deleteInputModel = await this._destinationService.GetDestinationForDeletingAsync(userId, id);

                if (deleteInputModel == null)
                {
                    return this.RedirectToAction(nameof(Index));
                }

                return this.View(deleteInputModel);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return this.RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DeleteDestinationInputModel inputModel)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    ModelState.AddModelError(string.Empty, "Please do not modify the page!");
                    return this.View(inputModel);
                }

                bool deleteResult = await this._destinationService.SoftDeleteDestinationAsync(this.GetUserId()!, inputModel);

                if (deleteResult == false)
                {
                    this.ModelState.AddModelError(string.Empty, "Fatal error occurred while deleting the destination!");
                    return this.View(inputModel);
                }

                return this.RedirectToAction(nameof(Index));

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return this.RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Favorites()
        {
            try
            {
                string userId = this.GetUserId()!;
                IEnumerable<FavoriteDestinationViewModel>? favDestinations = await this._destinationService.GetFavoriteDestinationsAsync(userId);

                if (favDestinations == null)
                {
                    return this.RedirectToAction(nameof(Index));
                }

                return this.View(favDestinations);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return this.RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddToFavorites(int? id)
        {
            try
            {
                string userId = this.GetUserId()!;

                if (id == null)
                {
                    return this.RedirectToAction(nameof(Index));
                }

                bool favAddResult = await this._destinationService.AddDestinationToUserFavoritesListAsync(userId, id.Value);

                if (favAddResult == false)
                {
                    return this.RedirectToAction(nameof(Index));
                }

                return this.RedirectToAction(nameof(Favorites));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return this.RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromFavorites(int? id)
        {
            try
            {
                string userId = this.GetUserId()!;

                if (id == null)
                {
                    return this.RedirectToAction(nameof(Index));
                }

                bool favRemoveResult = await this._destinationService.RemoveDestinationFromUserFavoritesListAsync(userId, id.Value);

                if (favRemoveResult == false)
                {
                    return this.RedirectToAction(nameof(Index));
                }

                return this.RedirectToAction(nameof(Favorites));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return this.RedirectToAction(nameof(Index));
            }
        }
    }
}
