namespace Homies.Services.Contracts
{
    using Data.Models;
    using Models.Event;

    public interface IEventService
    {
        Task<IEnumerable<EventInfoViewModel>> GetAllAsync();

        Task AddEventAsync(string userId, EventAddInputModel model);
        Task<EventAddInputModel> GetAddEventModelAsync();

        Task JoinEventAsync(Event eventData, string userId);
        Task<IEnumerable<EventInfoViewModel>> GetJoinedAsync(string userId);
        Task LeaveTheEventAsync(Event eventData, string userId);

        Task<EditEventInputModel?> GetEditModelAsync(int id);
        Task EditEventAsync(string userId, EditEventInputModel model);

        Task<EventDetailsViewModel?> GetEventDetailsAsync(Event eventData);
        Task<IEnumerable<TypeViewModel>> GetTypesAsync();
        Task<Event?> GetEventByIdAsync(int eventId);
    }
}
