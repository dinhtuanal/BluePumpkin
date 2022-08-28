using App.Models;
using DataAccessLayer.Entities;
using SharedObjects.Commons;

namespace App.Services.Interfaces
{
    public interface IUser
    {
        public Task<ResponseResult> Login(LoginViewModel model);
        public Task<ApplicationUser> GetByUserName(string userName, string token);
    }
}
