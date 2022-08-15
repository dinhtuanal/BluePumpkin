using App.Services.Interfaces;
using App.Services.common;
using App.Models;
using Newtonsoft.Json;

namespace App.Services.Implements
{
    public class Event : BaseClient, IEvent
    {
        public async Task<EventModel?> getEvent(string id)
        {
            var response = await httpClient.GetAsync("api/Events/get/" + id);
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<EventModel>(result);
        }

        public async Task<List<EventModel>?> getEvents()
        {
            var response = await httpClient.GetAsync("api/Events/get-all");
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<EventModel>>(result);
        }
    }
}
