using Clients.Interfaces;
using Newtonsoft.Json;
using SharedObjects.Commons;
using SharedObjects.ValueObjects;
using SharedObjects.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clients.Implements
{
    public class EventClient : BaseClient, IEventClient
    {
        public async Task<ResponseResult> Add(EventViewModel model, string token)
        {
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var multipart = new MultipartFormDataContent();
            var response = await httpClient.PostAsync("api/events/add", multipart);
            var apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ResponseResult>(apiResponse);
        }

        public async Task<int> Delete(string id, string token)
        {
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var response = await httpClient.DeleteAsync("api/events/" + id);
            var apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<int>(apiResponse);

        }

        public async Task<List<VEvent>> GetAll()
        {
            var response = await httpClient.GetAsync("api/events/get-all");
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<VEvent>>(content);
        }

        public async Task<VEvent> GetById(string id)
        {
            var response = await httpClient.GetAsync("api/events/" + id);
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<VEvent>(content);
        }

        public async Task<int> Update(EventViewModel model, string token)
        {
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync("api/events", content);
            var apiResponse = await response.Content.ReadAsStringAsync();
            var responseResult = JsonConvert.DeserializeObject<int>(apiResponse);
            return responseResult;
        }
    }
}
