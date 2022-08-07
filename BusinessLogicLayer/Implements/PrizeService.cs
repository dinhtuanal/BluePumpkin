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
    public class PrizeService : IPrizeService
    {
        private readonly BluePumpkinDbContext _context;
        public PrizeService(BluePumpkinDbContext context)
        {
            _context = context;
        }
        public async Task<int> Add(PrizeViewModel model)
        {
            var prize = new Prize
            {
                PrizeId = Guid.NewGuid(),
                PrizeName = model.PrizeName,
                Content = model.Content,
                Amount = model.Amount,
                Distributed = model.Distributed,
                Status = (Status)model.Status,
                EventId = Guid.Parse(model.EventId),
                CreatedBy = model.CreatedBy
            };
            _context.Prizes.Add(prize);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(string id)
        {
            var prize = await _context.Prizes.FindAsync(Guid.Parse(id));
            if (prize == null)
            {
                throw new CustomException("Can not find prize id !", 404);
            }
            _context.Prizes.Remove(prize);
            return await _context.SaveChangesAsync();
        }

        public List<VPrize> GetAll()
        {
            var query = from p in _context.Prizes
                            join e in _context.Events
                            on p.EventId equals e.EventId
                            select new VPrize
                            {
                                PrizeId = p.PrizeId,
                                PrizeName = p.PrizeName,
                                Content = p.Content,
                                Amount = p.Amount,
                                Distributed = p.Distributed,
                                Status = p.Status,
                                EventId = p.EventId,
                                CreatedBy = p.CreatedBy,
                                EventName = e.EventName
                            };
            return query.ToList();
        }

        public async Task<List<VPrize>> GetByEventId(string eventId)
        {
            var prizes = _context.Prizes.ToList();
            var vPrizes = prizes.ConvertAll(x => new VPrize
            {
                PrizeId = x.PrizeId,
                PrizeName = x.PrizeName,
                Content = x.Content,
                Amount = x.Amount,
                Distributed = x.Distributed,
                Status = x.Status,
                EventId = x.EventId,
                CreatedBy = x.CreatedBy
            });
            var prizesByEventId = new List<VPrize>();
            foreach(var item in vPrizes)
            {
                if(item.EventId == Guid.Parse(eventId))
                {
                    prizesByEventId.Add(item);
                }
            }
            return prizesByEventId;
        }

        public async Task<VPrize> GetById(string id)
        {
            var prizeById = await _context.Prizes.FindAsync(Guid.Parse(id));
            if (prizeById == null)
            {
                throw new CustomException("Can not find prize id", 404);
            }
            var vPrize = new VPrize
            {
                PrizeId = prizeById.PrizeId,
                PrizeName = prizeById.PrizeName,
                Content = prizeById.Content,
                Amount = prizeById.Amount,
                Distributed = prizeById.Distributed,
                Status = prizeById.Status,
                EventId = prizeById.EventId,
                CreatedBy = prizeById.CreatedBy
            };
            return vPrize;
        }

        public async Task<int> Update(PrizeViewModel model)
        {
            var prize = await _context.Prizes.FindAsync(Guid.Parse(model.PrizeId));
            if(prize == null)
            {
                throw new CustomException("Can not find prize id", 404);
            }
            prize.PrizeName = model.PrizeName;
            prize.Content = model.Content;
            prize.Amount = model.Amount;
            prize.Distributed = model.Distributed;
            prize.Status = (Status)model.Status;
            prize.EventId = Guid.Parse(model.EventId);
            prize.CreatedBy = model.CreatedBy;
            _context.Prizes.Update(prize);
            return await _context.SaveChangesAsync();

        }
    }
}
