namespace Homies.Services
{
    using Contracts;
    using Data;
    using Data.Models;
    using Models.Event;
    using System.Globalization;
    using Microsoft.EntityFrameworkCore;
    using static Common.ValidationConstants.Event;

    public class EventService : IEventService
    {
        private readonly HomiesDbContext _dbContext;

        public EventService(HomiesDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<IEnumerable<EventInfoViewModel>> GetAllAsync()
        {
            IEnumerable<EventInfoViewModel> allEvents = await this._dbContext
                .Events
                .AsNoTracking()
                .Select(e => new EventInfoViewModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    Start = e.Start.ToString(DateTimeFormat),
                    Type = e.Type.Name,
                    Organiser = e.Organiser.UserName ?? string.Empty
                })
                .ToArrayAsync();

            return allEvents;
        }

        public async Task AddEventAsync(string userId, EventAddInputModel model)
        {
            bool isValidStartDate = DateTime
                .TryParseExact(model.Start, DateTimeFormat,
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime startDate);

            bool isValidEndDate = DateTime
                .TryParseExact(model.End, DateTimeFormat,
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime endDate);

            if (isValidStartDate && isValidEndDate)
            {
                Event eventData = new Event
                {
                    CreatedOn = DateTime.Now,
                    Name = model.Name,
                    Description = model.Description,
                    Start = startDate,
                    End = endDate,
                    TypeId = model.TypeId,
                    OrganiserId = userId
                };

                await this._dbContext.Events.AddAsync(eventData);
                await this._dbContext.SaveChangesAsync();
            }
        }

        public async Task<EventAddInputModel> GetAddEventModelAsync()
        {
            IEnumerable<TypeViewModel> types = await this._dbContext
                .Types
                .AsNoTracking()
                .Select(t => new TypeViewModel
                {
                    Id = t.Id,
                    Name = t.Name
                })
                .ToArrayAsync();

            EventAddInputModel model = new EventAddInputModel
            {
                Types = types
            };

            return model;
        }

        public async Task JoinEventAsync(Event eventData, string userId)
        {
            Event? entity = await this._dbContext.Events
                .Where(e => e.Id == eventData.Id)
                .Include(e => e.EventsParticipants)
                .FirstOrDefaultAsync();

            if (entity != null && !entity.EventsParticipants.Any(p => p.HelperId == userId))
            {
                entity.EventsParticipants.Add(new EventParticipant()
                {
                    EventId = entity.Id,
                    HelperId = userId
                });

                await this._dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<EventInfoViewModel>> GetJoinedAsync(string userId)
        {
            IEnumerable<EventInfoViewModel> model = await _dbContext.EventsParticipants

                .Include(ep => ep.Event)
                    .ThenInclude(e => e.Type)
                .Include(ep => ep.Event)
                    .ThenInclude(e => e.Organiser)
                .AsNoTracking()
                .Where(ep => ep.HelperId == userId)
                .Select(ep => new EventInfoViewModel
                {
                    Id = ep.Event.Id,
                    Name = ep.Event.Name,
                    Start = ep.Event.Start.ToString(DateTimeFormat),
                    Type = ep.Event.Type.Name,
                    Organiser = ep.Event.Organiser.UserName ?? string.Empty
                })
                .ToArrayAsync();

            return model;
        }

        public async Task LeaveTheEventAsync(Event eventData, string userId)
        {
            EventParticipant? participant = await this._dbContext.EventsParticipants
                .FirstOrDefaultAsync(ep => ep.EventId == eventData.Id && ep.HelperId == userId);

            if (participant != null)
            {
                this._dbContext.EventsParticipants.Remove(participant);
                await this._dbContext.SaveChangesAsync();
            }
        }

        public async Task<EditEventInputModel?> GetEditModelAsync(int id)
        {
            EditEventInputModel? events = await this._dbContext.Events
                .Where(e => e.Id == id)
                .Select(e => new EditEventInputModel
                {
                    Id = e.Id, 
                    Name = e.Name,
                    Description = e.Description,
                    Start = e.Start.ToString(DateTimeFormat),
                    End = e.End.ToString(DateTimeFormat),
                    TypeId = e.TypeId
                })
                .FirstOrDefaultAsync();

            if (events == null)
            {
                return null;
            }

            events.Types = await GetTypesAsync();
            return events;
        }

        public async Task EditEventAsync(string userId, EditEventInputModel model)
        {

            Event? eventData = await this._dbContext
                .Events
                .FindAsync(model.Id);

            if (eventData == null)
            {
                return;
            }

            if (eventData.OrganiserId != userId)
            {
                return;
            }

            bool isValidStartDate = DateTime.TryParseExact(model.Start, DateTimeFormat,
                CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime startDate);
            bool isValidEndDate = DateTime.TryParseExact(model.End, DateTimeFormat,
                CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime endDate);

            if (isValidStartDate && isValidEndDate)
            {
                eventData.Name = model.Name;
                eventData.Description = model.Description;
                eventData.Start = startDate;
                eventData.End = endDate;
                eventData.TypeId = model.TypeId;

                await this._dbContext.SaveChangesAsync();
            }
        }

        public async Task<EventDetailsViewModel?> GetEventDetailsAsync(Event eventData)
        {
            EventDetailsViewModel? model = await this._dbContext
                .Events
                .Where(e => e.Id == eventData.Id)
                .Select(e => new EventDetailsViewModel
                {
                    Name = e.Name,
                    Description = e.Description,
                    Start = e.Start.ToString(DateTimeFormat),
                    End = e.End.ToString(DateTimeFormat),
                    Type = e.Type.Name,
                    Organiser = e.Organiser.UserName ?? string.Empty,
                })
                .FirstOrDefaultAsync();

            return model;
        }

        public async Task<IEnumerable<TypeViewModel>> GetTypesAsync()
        {
            return await this._dbContext
                .Types
                .AsNoTracking()
                .Select(t => new TypeViewModel
                {
                    Id = t.Id,
                    Name = t.Name
                })
                .ToArrayAsync();
        }

        public async Task<Event?> GetEventByIdAsync(int eventId)
        {
            return await this._dbContext
                .Events
                .FirstOrDefaultAsync(e => e.Id == eventId);
        }
    }
}
