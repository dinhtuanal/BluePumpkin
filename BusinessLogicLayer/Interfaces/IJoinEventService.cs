using SharedObjects.ValueObjects;
using SharedObjects.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IJoinEventService
    {
        public Task<int> Add(JoinEventViewModel model);
        public Task<int> Update(JoinEventViewModel model);
        public Task<int> Delete(string id);
        public List<VJoinEvent> GetAll();
        public Task<VJoinEvent> GetById(string id);
    }
}
