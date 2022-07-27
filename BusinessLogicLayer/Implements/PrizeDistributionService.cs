using BusinessLogicLayer.Interfaces;
using DataAccessLayer.DbContext;
using DataAccessLayer.Entities;
using SharedObjects.Commons;
using SharedObjects.ValueObjects;
using SharedObjects.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Implements
{
    public class PrizeDistributionService : IPrizeDistributionService
    {
        private readonly BluePumpkinDbContext _context;
        public PrizeDistributionService(BluePumpkinDbContext context)
        {
            _context = context;
        }
        public async Task<int> Add(PrizeDistributionViewModel model)
        {
            var prizeDistribution = new PrizeDistribution
            {
                PrizeDistributionId = Guid.NewGuid(),
                Status = (Status)model.Status,
                JoinEventId = Guid.Parse(model.JoinEventId),
                PrizeId = Guid.Parse(model.PrizeId),
                Ranking = model.Ranking,
                Amount = model.Amount,
                CreatedBy = model.CreatedBy,
            };
            _context.PrizeDistributions.Add(prizeDistribution);
            return await _context.SaveChangesAsync();

        }

        public async Task<int> Delete(string id)
        {
            var prizeDistribution = await _context.PrizeDistributions.FindAsync(Guid.Parse(id));
            if (prizeDistribution == null)
            {
                throw new BluePumpkinException("Can not find prize distribution id !");
            }
            _context.PrizeDistributions.Remove(prizeDistribution);
            return await _context.SaveChangesAsync();
        }

        public List<VPrizeDistribution> GetAll()
        {
            var prizeDistributions = _context.PrizeDistributions.ToList();
            var vPrizeDistributions = prizeDistributions.ConvertAll(x => new VPrizeDistribution
            {
                PrizeDistributionId = x.PrizeDistributionId,
                Status = x.Status,
                JoinEventId = x.JoinEventId,
                PrizeId = x.PrizeId,
                Ranking = x.Ranking,
                Amount = x.Amount,
                CreatedBy = x.CreatedBy,
            });
            return vPrizeDistributions;
        }

        public async Task<VPrizeDistribution> GetById(string id)
        {
            var prizeDistribution = await _context.PrizeDistributions.FindAsync(Guid.Parse(id));
            var vPrizeDistribution = new VPrizeDistribution
            {
                PrizeDistributionId = prizeDistribution.PrizeDistributionId,
                Status = prizeDistribution.Status,
                JoinEventId = prizeDistribution.JoinEventId,
                PrizeId = prizeDistribution.PrizeId,
                Ranking = prizeDistribution.Ranking,
                Amount = prizeDistribution.Amount,
                CreatedBy = prizeDistribution.CreatedBy,
            };
            return vPrizeDistribution;
        }

        public async Task<int> Update(PrizeDistributionViewModel model)
        {
            var prizeDistribution = await _context.PrizeDistributions.FindAsync(Guid.Parse(model.PrizeDistributionId));
            if(prizeDistribution == null)
            {
                throw new BluePumpkinException("Can not find prize distribution id !");
            }
            prizeDistribution.Status = (Status)model.Status;
            prizeDistribution.JoinEventId= Guid.Parse(model.JoinEventId);
            prizeDistribution.PrizeId= Guid.Parse(model.PrizeId);
            prizeDistribution.Ranking= model.Ranking;
            prizeDistribution.Amount = model.Amount;
            prizeDistribution.CreatedBy = model.CreatedBy;
            _context.PrizeDistributions.Update(prizeDistribution);
            return await _context.SaveChangesAsync();
        }
    }
}
