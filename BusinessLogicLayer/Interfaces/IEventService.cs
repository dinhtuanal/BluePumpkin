using SharedObjects.ValueObjects;
using SharedObjects.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IEventService
    {
        public Task<int> Add(EventViewModel model);
        public Task<int> Update(EventViewModel model);
        public Task<int> Delete(string id);
        public List<VEvent> GetAll();
        public Task<VEvent> GetById(string id);
    }
}
