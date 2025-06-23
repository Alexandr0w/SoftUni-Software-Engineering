using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using RecipeSharingPlatform.Services.Core.Contracts;
using RecipeSharingPlatform.ViewModels.Recipe;
using static RecipeSharingPlatform.GCommon.ValidationConstants.Recipe;

namespace RecipeSharingPlatform.Web.Controllers
{
    public class RecipeController : BaseController
    {
        private readonly IRecipeService _recipeService;
        private readonly ICategoryService _categoryService;

        public RecipeController(IRecipeService recipeService, ICategoryService iCategoryService)
        {
            this._recipeService = recipeService;
            this._categoryService = iCategoryService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            try
            {
                string userId = this.GetUserId();
                IEnumerable<RecipeIndexViewModel> allRecipes = await this._recipeService.GetAllRecipesAsync(userId);
                return this.View(allRecipes);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return this.RedirectToAction(nameof(Index), "Home");
            }
        } 

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            try
            {
                CreateRecipeInputModel addRecipeInputModel = new CreateRecipeInputModel()
                {
                    CreatedOn = DateTime.UtcNow.ToString(CreatedOnFormat, CultureInfo.InvariantCulture),
                    Categories = await this._categoryService.GetCategoriesDropDownAsync(),
                };

                return this.View(addRecipeInputModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return this.RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRecipeInputModel inputModel)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    inputModel.Categories = await this._categoryService.GetCategoriesDropDownAsync();
                    return this.View(inputModel);
                }

                bool addResult = await this._recipeService.CreateRecipeAsync(this.GetUserId(), inputModel);

                if (addResult == false)
                {
                    ModelState.AddModelError(string.Empty, CreateErrorMessage);
                    inputModel.Categories = await _categoryService.GetCategoriesDropDownAsync();
                    return this.View(inputModel);
                }

                return this.RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return this.RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                string? userId = this.GetUserId();
                DetailsRecipeViewModel? recipeDetails = await this._recipeService.GetRecipeDetailsAsync(userId, id);

                if (recipeDetails == null)
                {
                    return this.RedirectToAction(nameof(Index));
                }

                return this.View(recipeDetails);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return this.RedirectToAction(nameof(Index)); 
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                string? userId = this.GetUserId();
                DeleteRecipeInputModel? deleteRecipeInputModel = await this._recipeService.GetRecipeForDeletingAsync(userId, id);

                if (deleteRecipeInputModel == null)
                {
                    return this.RedirectToAction(nameof(Index));
                }

                return this.View(deleteRecipeInputModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return this.RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmDelete(DeleteRecipeInputModel inputModel)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    ModelState.AddModelError(string.Empty, NotModifyMessage);
                    return this.View(inputModel);
                }

                bool deleteResult = await this._recipeService.SoftDeleteRecipeAsync(this.GetUserId()!, inputModel);

                if (deleteResult == false)
                {
                    ModelState.AddModelError(string.Empty, DeleteErrorMessage);
                    return this.View(inputModel);
                }
                return this.RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return this.RedirectToAction(nameof(Index));
            }

        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                string userId = this.GetUserId()!;
                EditRecipeInputModel? editRecipeInputModel = await this._recipeService.GetRecipeForEditingAsync(userId, id);

                if (editRecipeInputModel == null)
                {
                    return this.RedirectToAction(nameof(Index));
                }

                editRecipeInputModel.Categories = await _categoryService.GetCategoriesDropDownAsync();
                return this.View(editRecipeInputModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return this.RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditRecipeInputModel inputModel)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    return this.View(inputModel);
                }

                bool editResult = await this._recipeService.PersistUpdatedRecipeAsync(this.GetUserId()!, inputModel);

                if (editResult == false)
                {
                    this.ModelState.AddModelError(string.Empty, EditErrorMessage);
                    return this.View(inputModel);
                }

                return this.RedirectToAction(nameof(Details), new { id = inputModel.Id });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return this.RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Favorites()
        {
            try
            {
                string? userId = this.GetUserId();
                IEnumerable<FavoriteRecipeViewModel>? favoriteRecipes = await this._recipeService.GetFavoriteRecipesAsync(userId);

                if(favoriteRecipes == null)
                {
                    return this.RedirectToAction(nameof(Index));
                }

                return this.View(favoriteRecipes);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return this.RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Save(int? id)
        {
            try
            {
                string userId = this.GetUserId();

                if (id == null)
                {
                    return this.RedirectToAction(nameof(Index));
                }

                bool favAddResult = await this._recipeService.AddRecipeToUserFavoritesListAsync(userId, id.Value);

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
        public async Task<IActionResult> Remove(int? id)
        {
            try
            {
                string userId = this.GetUserId();

                if (id == null)
                {
                    return this.RedirectToAction(nameof(Index));
                }

                bool favRemoveResult = await this._recipeService.RemoveRecipeFromUserFavoritesListAsync(userId, id.Value);

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