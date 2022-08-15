using App.Models;

namespace App.Services.Interfaces
{
    public interface IEvent
    {
        public Task<List<EventModel>?> getEvents();
        public Task<EventModel?> getEvent(string id);
    }
}
