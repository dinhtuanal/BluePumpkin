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
    public interface IQuestionClient
    {
        public Task<List<VQuestion>> GetAll();
        public Task<VQuestion> GetId(string id);
        public Task<ResponseResult> Add(QuestionViewModel model, string token);
        public Task<ResponseResult> Update(QuestionViewModel model, string token);
        public Task<ResponseResult> Delete(string id, string token);

    }
}
