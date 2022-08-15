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
    public class PrizeDistributionClient : BaseClient, IPrizeDistributionClient
    {
        public async Task<ResponseResult> Add(PrizeDistributionViewModel model, string token)
        {
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("api/prizedistributions/add", content);
            var apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ResponseResult>(apiResponse);
        }

        public async Task<ResponseResult> Delete(string id, string token)
        {
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var response = await httpClient.DeleteAsync("api/prizedistributions/delete/" + id);
            var apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ResponseResult>(apiResponse);
        }

        public async Task<List<VPrizeDistribution>> GetAll()
        {
            var response = await httpClient.GetAsync("api/prizedistributions/get-all");
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<VPrizeDistribution>>(content);
        }

        public async Task<VPrizeDistribution> GetById(string id)
        {
            var response = await httpClient.GetAsync("api/prizedistributions/get/" + id);
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<VPrizeDistribution>(content);
        }

        public async Task<ResponseResult> Update(PrizeDistributionViewModel model, string token)
        {
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync("api/prizedistributions", content);
            var apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ResponseResult>(apiResponse);
        }
    }
}
