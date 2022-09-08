using App.Services.common;
using App.Services.Interfaces;
using Newtonsoft.Json;
using SharedObjects.Commons;
using SharedObjects.ViewModels;
using System.Text;

namespace App.Services.Implements
{
    public class JointEvent : BaseClient, IJointEvent
    {
        public async Task<ResponseResult> Add(JoinEventViewModel model, string token)
        {
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("api/joinevents/add", content);
            var apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ResponseResult>(apiResponse);
        }
    }
}
