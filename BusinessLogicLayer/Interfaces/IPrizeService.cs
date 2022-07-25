using SharedObjects.ValueObjects;
using SharedObjects.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IPrizeService
    {
        public Task<int> Add(PrizeViewModel model);
        public Task<int> Update(PrizeViewModel model);
        public Task<int> Delete(string id);
        public Task<VPrize> GetById(string id);
        public Task<List<VPrize>> GetByEventId(string eventId);
        public List<VPrize> GetAll();
    }
}
