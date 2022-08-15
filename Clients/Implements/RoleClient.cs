using Clients.Interfaces;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity;
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
    public class RoleClient : BaseClient, IRoleClient
    {
        public async Task<ResponseResult> Add(RoleViewModel model, string token)
        {
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("api/roles/add", content);
            var apiResponse = await response.Content.ReadAsStringAsync();
            var responseResult = JsonConvert.DeserializeObject<ResponseResult>(apiResponse);
            return responseResult;
        }

        public async Task<ResponseResult> AssignRole(UserRoleViewModel model, string token)
        {
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("api/Roles/assign-role", content);
            var apiResponse = await response.Content.ReadAsStringAsync();
            var responseResult = JsonConvert.DeserializeObject<ResponseResult>(apiResponse);
            return responseResult;
        }

        public async Task<ResponseResult> Delete(string roleId, string token)
        {
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var response = await httpClient.DeleteAsync("api/roles/delete/" + roleId);
            var apiResponse = await response.Content.ReadAsStringAsync();
            var responseResult = JsonConvert.DeserializeObject<ResponseResult>(apiResponse);
            return responseResult;
        }

        public async Task<List<IdentityRole>> GetAll(string token)
        {
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var response = await httpClient.GetAsync("api/roles");
            var apiResponse = await response.Content.ReadAsStringAsync();
            var responseResult = JsonConvert.DeserializeObject<List<IdentityRole>>(apiResponse);
            return responseResult;
        }

        public async Task<IdentityRole> GetById(string roleId, string token)
        {
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var response = await httpClient.GetAsync("api/roles/" + roleId);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IdentityRole>(apiResponse);
            return result;
        }

        public async Task<List<ApplicationUser>> GetUserInRole(string roleName, string token)
        {
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var response = await httpClient.GetAsync("api/Roles/user-in-role/" + roleName);
            var apiResponse = await response.Content.ReadAsStringAsync();
            var responseResult = JsonConvert.DeserializeObject<List<ApplicationUser>>(apiResponse);
            return responseResult;
        }

        public async Task<List<ApplicationUser>> GetUserNotInRole(string roleName, string token)
        {
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var response = await httpClient.GetAsync("api/Roles/user-not-in-role/" + roleName);
            var apiResponse = await response.Content.ReadAsStringAsync();
            var responseResult = JsonConvert.DeserializeObject<List<ApplicationUser>>(apiResponse);
            return responseResult;
        }

        public async Task<ResponseResult> RemoveRole(UserRoleViewModel model, string token)
        {
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("api/roles/remove-role", content);
            var apiResponse = await response.Content.ReadAsStringAsync();
            var responseResult = JsonConvert.DeserializeObject<ResponseResult>(apiResponse);
            return responseResult;
        }

        public async Task<ResponseResult> Update(RoleViewModel model, string token)
        {
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync("api/roles/update", content);
            var apiResponse = await response.Content.ReadAsStringAsync();
            var responseResult = JsonConvert.DeserializeObject<ResponseResult>(apiResponse);
            return responseResult;
        }
    }
}
