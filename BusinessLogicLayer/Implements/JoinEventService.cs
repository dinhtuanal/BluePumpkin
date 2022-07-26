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
    public class JoinEventService : IJoinEventService
    {
        private readonly BluePumpkinDbContext _context;
        public JoinEventService(BluePumpkinDbContext context)
        {
            _context = context;
        }
        public async Task<int> Add(JoinEventViewModel model)
        {
            var joinevent = new JoinEvent
            {
                JoinEventId = Guid.NewGuid(),
                JoinEventStatus = (JoinEventStatus)model.JoinEventStatus,
                EventId = Guid.Parse(model.JoinEventId),
                UserId = model.UserId,
                Description = model.Description,
                CreatedBy = model.CreatedBy,
            };
            _context.JoinEvents.Add(joinevent);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(string id)
        {
            if (id == null)
            {
                throw new BluePumpkinException("Please enter join event id !");
            }
            var joinevent = await _context.JoinEvents.FindAsync(Guid.Parse(id));
            if(joinevent == null)
            {
                throw new BluePumpkinException("Can not find join event id");
            }
            _context.JoinEvents.Remove(joinevent);
            return await _context.SaveChangesAsync();
        }

        public List<VJoinEvent> GetAll()
        {
            var joinevents = _context.JoinEvents.ToList();
            var vJoinevent = joinevents.ConvertAll(x => new VJoinEvent
            {
                JoinEventId = x.JoinEventId,
                JoinEventStatus = x.JoinEventStatus,
                EventId = x.EventId,
                UserId = x.UserId,
                Description = x.Description,
                CreatedBy = x.CreatedBy,
            });
            return vJoinevent;
        }

        public async Task<VJoinEvent> GetById(string id)
        {
            var joinevents = await _context.JoinEvents.FindAsync(Guid.Parse(id));
            var vJoinevent =  new VJoinEvent
            {
                JoinEventId = joinevents.JoinEventId,
                JoinEventStatus = joinevents.JoinEventStatus,
                EventId = joinevents.EventId,
                UserId = joinevents.UserId,
                Description = joinevents.Description,
                CreatedBy = joinevents.CreatedBy,
            };
            return vJoinevent;
        }

        public async Task<int> Update(JoinEventViewModel model)
        {
            var joinevent = await _context.JoinEvents.FindAsync(Guid.Parse(model.JoinEventId));
            joinevent.JoinEventStatus = (JoinEventStatus)model.JoinEventStatus;
            joinevent.EventId = Guid.Parse(model.EventId);
            joinevent.UserId = model.UserId;
            joinevent.Description = model.Description;
            joinevent.CreatedBy = model.CreatedBy;
            _context.JoinEvents.Update(joinevent);
            return await _context.SaveChangesAsync();
        }
    }
}
