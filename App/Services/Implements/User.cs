using App.Models;
using App.Services.common;
using App.Services.Interfaces;
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
    }
}
