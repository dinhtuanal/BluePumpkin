using SharedObjects.Commons;
using SharedObjects.ViewModels;

namespace App.Services.Interfaces
{
    public interface IJointEvent
    {
        public Task<ResponseResult> Add(JoinEventViewModel model, string token);
    }
}
