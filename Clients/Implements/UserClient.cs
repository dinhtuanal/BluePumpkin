using Clients.Interfaces;
using DataAccessLayer.Entities;
using Newtonsoft.Json;
using SharedObjects.Commons;
using SharedObjects.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clients.Implements
{
    public class UserClient : BaseClient, IUserClient
    {
        public async Task<ResponseResult> Add(AddUserViewModel model, string token)
        {
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("api/Auth/add", content);
            var apiResponse = await response.Content.ReadAsStringAsync();
            var responseResult = JsonConvert.DeserializeObject<ResponseResult>(apiResponse);
            return responseResult;
        }

        public async Task<ResponseResult> Delete(string userId, string token)
        {
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var response = await httpClient.DeleteAsync("api/auth/delete/" + userId);
            var apiResponse = await response.Content.ReadAsStringAsync();
            var responseResult = JsonConvert.DeserializeObject<ResponseResult>(apiResponse);
            return responseResult;
        }

        public async Task<List<ApplicationUser>> GetAll(string token)
        {
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var response = await httpClient.GetAsync("api/auth/get-all");
            var apiResponse = await response.Content.ReadAsStringAsync();
            var responseResult = JsonConvert.DeserializeObject<List<ApplicationUser>>(apiResponse);
            return responseResult;
        }

        public async Task<ApplicationUser> GetById(string userId, string token)
        {
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var response = await httpClient.GetAsync("api/auth/get-by-id/" + userId);
            var apiResponse = await response.Content.ReadAsStringAsync();
            var responseResult = JsonConvert.DeserializeObject<ApplicationUser>(apiResponse);
            return responseResult;
        }

        public async Task<ResponseResult> Login(LoginViewModel model)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("api/auth/login", content);
            var apiResponse = await response.Content.ReadAsStringAsync();
            var responseResult = JsonConvert.DeserializeObject<ResponseResult>(apiResponse);
            return responseResult;
        }

        public async Task<ResponseResult> Update(UpdateUserViewModel model, string token)
        {
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync("api/auth/update", content);
            var apiResponse = await response.Content.ReadAsStringAsync();
            var responseResult = JsonConvert.DeserializeObject<ResponseResult>(apiResponse);
            return responseResult;
        }
    }
}
