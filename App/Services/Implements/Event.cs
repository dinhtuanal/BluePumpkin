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

            try
            {
                return JsonConvert.DeserializeObject<EventModel>(result);
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public async Task<List<EventModel>?> getEvents()
        {
            var response = await httpClient.GetAsync("api/Events/get-all");
            var result = await response.Content.ReadAsStringAsync();
            try
            {
                return JsonConvert.DeserializeObject<List<EventModel>>(result);
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public async Task<List<JoinEvent>?> getJoinEvents()
        {
            var response = await httpClient.GetAsync("api/JoinEvents/get-all");
            var result = await response.Content.ReadAsStringAsync();

            try
            {
                return JsonConvert.DeserializeObject<List<JoinEvent>>(result);
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}
