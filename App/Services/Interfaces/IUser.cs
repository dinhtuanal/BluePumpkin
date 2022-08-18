using App.Models;
using SharedObjects.Commons;

namespace App.Services.Interfaces
{
    public interface IUser
    {
        public Task<ResponseResult> Login(LoginViewModel model);
    }
}
