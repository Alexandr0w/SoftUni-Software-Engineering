namespace GameZone.Controllers
{
    using Models;
    using Data.Models;
    using Services.Contracts;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    [Authorize]
    public class GameController : BaseController
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            this._gameService = gameService;
        }

        public async Task<IActionResult> All()
        {
            try
            {
                IEnumerable<GameInfoViewModel> allGames = await this._gameService.GetAllAsync();
                return this.View(allGames);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return this.RedirectToAction(nameof(All));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            try
            {
                GameViewModel model = await this._gameService.GetAddModelAsync();
                return this.View(model);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return this.RedirectToAction(nameof(All));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(GameViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return this.View(model);
                }

                string userId = GetUserId() ?? string.Empty;

                if (userId != null)
                {
                    await this._gameService.AddGameAsync(model, userId);
                }

                return this.RedirectToAction(nameof(All));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return this.RedirectToAction(nameof(All));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                string userId = GetUserId() ?? string.Empty;

                GameViewModel? editModel = await this._gameService.GetEditModelAsync(id);

                if (editModel == null)
                {
                    return this.RedirectToAction(nameof(All));
                }

                return this.View(editModel);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return this.RedirectToAction(nameof(All));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, GameViewModel editModel)
        {
            try
            {
                Game? game = await this._gameService.GetGameByIdAsync(id);

                if (game == null)
                {
                    return BadRequest();
                }

                string userId = GetUserId() ?? string.Empty;

                if (game.PublisherId != userId)
                {
                    return this.RedirectToAction(nameof(All));
                }

                await this._gameService.EditGameAsync(editModel, game);
                return RedirectToAction(nameof(All));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return this.RedirectToAction(nameof(All));
            }
        }

        [HttpGet]
        public async Task<IActionResult> MyZone()
        {
            try
            {
                string userId = GetUserId() ?? string.Empty;
                IEnumerable<GameInfoViewModel> model = await this._gameService.GetMyZоneAsync(userId);

                return this.View(model);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return this.RedirectToAction(nameof(All));
            }
        }

        [HttpGet]
        public async Task<IActionResult> AddToMyZone(int id)
        {
            try
            {
                Game? game = await this._gameService.GetGameByIdAsync(id);

                if (game == null)
                {
                    return BadRequest();
                }

                string userId = GetUserId() ?? string.Empty;

                if (game.GamersGames.Any(gg => gg.GamerId == userId))
                {
                    return RedirectToAction(nameof(All));
                }

                await this._gameService.AddGameToMyZoneAsync(userId, game);

                return RedirectToAction(nameof(MyZone));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return this.RedirectToAction(nameof(All));
            }
        }

        [HttpGet]
        public async Task<IActionResult> StrikeOut(int id)
        {
            try
            {
                Game? game = await this._gameService.GetGameByIdAsync(id);

                if (game == null)
                {
                    return BadRequest();
                }

                string userId = GetUserId() ?? string.Empty;
                await this._gameService.StrikeOutAsync(userId, game);

                return RedirectToAction(nameof(MyZone));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return this.RedirectToAction(nameof(All));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                GameDetailsViewModel? model = await this._gameService.GetGameDetails(id);

                if (model == null)
                {
                    return BadRequest();
                }

                return this.View(model);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return this.RedirectToAction(nameof(All));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                GameDeleteViewModel? model = await this._gameService.GetGameForDeleteAsync(id);

                if (model == null)
                {
                    return BadRequest();
                }

                return this.View(model);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return this.RedirectToAction(nameof(All));
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id, GameDeleteViewModel model)
        {
            try
            {
                Game? game = await this._gameService.GetGameByIdAsync(id);

                if (game == null)
                {
                    return BadRequest();
                }

                await this._gameService.SoftDeleteGameAsync(model);
                return RedirectToAction(nameof(All));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return this.RedirectToAction(nameof(All));
            }
        }
    }
}
