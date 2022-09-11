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
    public class JoinEventClient : BaseClient, IJoinEventClient
    {
        public async Task<ResponseResult> Add(JoinEventViewModel model, string token)
        {
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("api/joinevents/add", content);
            var apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ResponseResult>(apiResponse);
        }

        public async Task<ResponseResult> Delete(string id, string token)
        {
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var response = await httpClient.DeleteAsync("api/joinevents/delete/" + id);
            var apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ResponseResult>(apiResponse);
        }

        public async Task<List<VJoinEvent>> GetAll()
        {
            var response = await httpClient.GetAsync("api/joinevents/get-all");
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<VJoinEvent>>(content);
        }

        public async Task<VJoinEvent> GetById(string id)
        {
            var response = await httpClient.GetAsync("api/joinevents/get/" + id);
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<VJoinEvent>(content);
        }

        public async Task<ResponseResult> Update(JoinEventViewModel model, string token)
        {
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync("api/joinevents/update", content);
            var apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ResponseResult>(apiResponse);
        }
    }
}
