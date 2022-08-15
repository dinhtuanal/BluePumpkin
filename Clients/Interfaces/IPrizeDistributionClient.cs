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
    public interface IPrizeDistributionClient
    {
        public Task<ResponseResult> Add(PrizeDistributionViewModel model, string token);
        public Task<ResponseResult> Update(PrizeDistributionViewModel model, string token);
        public Task<ResponseResult> Delete(string id, string token);
        public Task<List<VPrizeDistribution>> GetAll();
        public Task<VPrizeDistribution> GetById(string id);
    }
}
