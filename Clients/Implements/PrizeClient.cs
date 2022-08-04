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
    public class PrizeClient : BaseClient, IPrizeClient
    {
        public async Task<ResponseResult> Add(PrizeViewModel model, string token)
        {
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("api/prizes/add", content);
            var apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ResponseResult>(apiResponse);
        }

        public async Task<ResponseResult> Delete(string id, string token)
        {
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var response = await httpClient.DeleteAsync("api/prizes/delete/" + id);
            var apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ResponseResult>(apiResponse);
        }

        public async Task<List<VPrize>> GetAll()
        {
            var response = await httpClient.GetAsync("api/prizes/get-all");
            var apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<VPrize>>(apiResponse);
        }

        public async Task<List<VPrize>> GetByEventId(string eventId)
        {
            var response = await httpClient.GetAsync("api/prizes/get-by-event-id/" + eventId);
            var apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<VPrize>>(apiResponse);
        }

        public async Task<VPrize> GetById(string id)
        {
            var response = await httpClient.GetAsync("api/prizes/get/" + id);
            var apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<VPrize>(apiResponse);
        }

        public async Task<ResponseResult> Update(PrizeViewModel model, string token)
        {
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync("api/prizes/update", content);
            var apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ResponseResult>(apiResponse);
        }
    }
}
