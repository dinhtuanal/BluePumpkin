using DataAccessLayer.Entities;
using SharedObjects.Commons;
using SharedObjects.ViewModels;

namespace BusinessLogicLayer.Interfaces
{
    public interface IUserService
    {
        Task<ResponseResult> Login(LoginViewModel model);
        Task<ResponseResult> Add(AddUserViewModel model);
        Task<ResponseResult> Update(UpdateUserViewModel model);
        Task<ResponseResult> Delete(string userId);
        List<ApplicationUser> GetAll();
        Task<ApplicationUser> GetById(string userId);
        Task<ApplicationUser> GetByUserName(string username);
    }
}
