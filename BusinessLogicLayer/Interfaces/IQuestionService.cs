using SharedObjects.ValueObjects;
using SharedObjects.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IQuestionService
    {
        public Task<int> Add(QuestionViewModel model);
        public Task<int> Update(QuestionViewModel model);
        public Task<int> Delete(string id);
        public List<VQuestion> GetAll();
        public Task<VQuestion> GetById(string id);
    }
}
