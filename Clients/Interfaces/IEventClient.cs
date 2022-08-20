using Microsoft.AspNetCore.Http;
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
    public interface IEventClient
    {
        public Task<ResponseResult> Add(EventViewModel model, string token);
        public Task<ResponseResult> Update(EventViewModel model, string token);
        public Task<ResponseResult> Delete(string id, string token);
        public Task<List<VEvent>> GetAll();
        public Task<VEvent> GetById(string id);
    }
}
