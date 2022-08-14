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
    public interface IJoinEventClient
    {
        public Task<ResponseResult> Add(JoinEventViewModel model, string token);
        public Task<ResponseResult> Update(JoinEventViewModel model, string token);
        public Task<ResponseResult> Delete(string id, string token);
        public Task<List<VJoinEvent>> GetAll();
        public Task<VJoinEvent> GetById(string id);
    }
}
