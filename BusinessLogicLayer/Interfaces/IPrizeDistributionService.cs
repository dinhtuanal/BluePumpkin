using DataAccessLayer.Entities;
using SharedObjects.ValueObjects;
using SharedObjects.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IPrizeDistributionService
    {
        public Task<int> Add(PrizeDistributionViewModel model);
        public Task<int> Update(PrizeDistributionViewModel model);
        public Task<int> Delete(string id);
        public Task<VPrizeDistribution> GetById(string id);
        public List<VPrizeDistribution> GetAll();
    }
}
