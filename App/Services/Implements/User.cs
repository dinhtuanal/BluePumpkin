using App.Models;
using App.Services.common;
using App.Services.Interfaces;
using DataAccessLayer.Entities;
using Newtonsoft.Json;
using SharedObjects.Commons;
using System.Text;

namespace App.Services.Implements
{
    public class User : BaseClient, IUser
    {
        public async Task<ResponseResult> Login(LoginViewModel model)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("api/auth/login", content);
            var apiResponse = await response.Content.ReadAsStringAsync();
            var responseResult = JsonConvert.DeserializeObject<ResponseResult>(apiResponse);
            return responseResult;
        }
        public async Task<ApplicationUser> GetByUserName(string userName, string token)
        {
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var response = await httpClient.GetAsync("api/Auth/get-by-username/" + userName);
            var apiResponse = await response.Content.ReadAsStringAsync();
            var responseResult = JsonConvert.DeserializeObject<ApplicationUser>(apiResponse);
            return responseResult;
        }
    }
}
