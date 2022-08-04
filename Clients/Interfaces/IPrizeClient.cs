using SharedObjects.Commons;
using SharedObjects.ValueObjects;
using SharedObjects.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clients.Interfaces
{
    public interface IPrizeClient
    {
        public Task<ResponseResult> Add(PrizeViewModel model, string token);
        public Task<ResponseResult> Update(PrizeViewModel model, string token);
        public Task<ResponseResult> Delete(string id, string token);
        public Task<VPrize> GetById(string id);
        public Task<List<VPrize>> GetByEventId(string eventId);
        public Task<List<VPrize>> GetAll();
    }
}
