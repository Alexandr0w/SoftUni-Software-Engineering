namespace Homies.Controllers
{
    using Homies.Data.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models.Event;
    using Services.Contracts;

    [Authorize]
    public class EventController : BaseController
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            this._eventService = eventService;
        }

        public async Task<IActionResult> All()
        {
            try
            {
                IEnumerable<EventInfoViewModel> allEvents = await this._eventService.GetAllAsync();
                return this.View(allEvents);
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
                EventAddInputModel model = await this._eventService.GetAddEventModelAsync();
                return this.View(model);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return this.RedirectToAction(nameof(All));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(EventAddInputModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                string? userId = GetUserId();
                if (string.IsNullOrEmpty(userId))
                {
                    return Unauthorized();
                }

                await this._eventService.AddEventAsync(userId, model);
                return this.RedirectToAction(nameof(All));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return this.RedirectToAction(nameof(All));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Joined()
        {
            try
            {
                string? userId = GetUserId();
                if (string.IsNullOrEmpty(userId))
                {
                    return Unauthorized();
                }

                IEnumerable<EventInfoViewModel>? joinedEvents = await this._eventService.GetJoinedAsync(userId);
                return this.View(joinedEvents);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return this.RedirectToAction(nameof(All));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Join(Event joinEvent)
        {
            try
            {
                if (joinEvent == null)
                {
                    return BadRequest();
                }

                string? userId = GetUserId();
                if (string.IsNullOrEmpty(userId))
                {
                    return Unauthorized();
                }

                await this._eventService.JoinEventAsync(joinEvent, userId);
                return this.RedirectToAction(nameof(Joined));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return this.RedirectToAction(nameof(All));
            }
        }

        public async Task<IActionResult> Leave(Event eventToLeave, int id)
        {
            try
            {
                if (eventToLeave == null)
                {
                    return BadRequest();
                }

                string? userId = GetUserId();
                if (string.IsNullOrEmpty(userId))
                {
                    return Unauthorized();
                }

                await this._eventService.LeaveTheEventAsync(eventToLeave, userId);
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
                EditEventInputModel? model = await this._eventService.GetEditModelAsync(id);

                if (model == null)
                {
                    return NotFound();
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
        public async Task<IActionResult> Edit(int id, EditEventInputModel inputModel)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    inputModel.Types = await this._eventService.GetTypesAsync(); 
                    return this.View(inputModel);
                }

                if (inputModel == null)
                {
                    return BadRequest();
                }

                inputModel.Id = id;

                string? userId = this.GetUserId();
                if (string.IsNullOrEmpty(userId))
                {
                    return Unauthorized();
                }

                await this._eventService.EditEventAsync(userId, inputModel);
                return this.RedirectToAction(nameof(All));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return this.RedirectToAction(nameof(All));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Details(Event eventData)
        {
            try
            {
                EventDetailsViewModel? model = await this._eventService.GetEventDetailsAsync(eventData);

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
    }
}
