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
    public class QuestionClient : BaseClient, IQuestionClient
    {
        public async Task<ResponseResult> Add(QuestionViewModel model, string token)
        {
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("api/questions/add", content);
            var apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ResponseResult>(apiResponse);
        }

        public async Task<ResponseResult> Delete(string id, string token)
        {
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var response = await httpClient.DeleteAsync("api/questions/delete/" + id);
            var apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ResponseResult>(apiResponse);
        }

        public async Task<List<VQuestion>> GetAll()
        {
            var response = await httpClient.GetAsync("api/questions/get-all");
            var apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<VQuestion>>(apiResponse);
        }

        public async Task<VQuestion> GetId(string id)
        {
            var response = await httpClient.GetAsync("api/questions/get/" + id);
            var apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<VQuestion>(apiResponse);
        }

        public async Task<ResponseResult> Update(QuestionViewModel model, string token)
        {
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync("api/questions/update", content);
            var apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ResponseResult>(apiResponse);
        }
    }
}
