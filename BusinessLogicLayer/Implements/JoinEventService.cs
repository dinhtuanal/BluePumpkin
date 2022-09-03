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
                JoinEventStatus = JoinEventStatus.Peding,
                EventId = Guid.Parse(model.EventId),
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
                throw new CustomException("Please enter join event id !", 400);
            }
            var joinevent = await _context.JoinEvents.FindAsync(Guid.Parse(id));
            if(joinevent == null)
            {
                throw new CustomException("Can not find join event id", 404);
            }
            _context.JoinEvents.Remove(joinevent);
            return await _context.SaveChangesAsync();
        }

        public List<VJoinEvent> GetAll()
        {
            var query = from j in _context.JoinEvents
                        join e in _context.Events on j.EventId equals e.EventId
                        join u in _context.Users on j.UserId equals u.Id
                        select new VJoinEvent
                        {
                            JoinEventId = j.JoinEventId,
                            JoinEventStatus = j.JoinEventStatus,
                            EventId = j.EventId,
                            UserId = j.UserId,
                            Description = j.Description,
                            CreatedBy = j.CreatedBy,
                            EventName = e.EventName,
                            UserName = u.UserName
                        };
            return query.ToList();
        }

        public async Task<VJoinEvent> GetById(string id)
        {
            var query = from j in _context.JoinEvents
                        join e in _context.Events on j.EventId equals e.EventId
                        join u in _context.Users on j.UserId equals u.Id
                        select new VJoinEvent
                        {
                            JoinEventId = j.JoinEventId,
                            JoinEventStatus = j.JoinEventStatus,
                            EventId = j.EventId,
                            UserId = j.UserId,
                            Description = j.Description,
                            CreatedBy = j.CreatedBy,
                            EventName = e.EventName,
                            UserName = u.UserName
                        };
            return query.Where(e => e.JoinEventId == Guid.Parse(id)).FirstOrDefault();
            /*var joinevents = await _context.JoinEvents.FindAsync(Guid.Parse(id));
            var vJoinevent =  new VJoinEvent
            {
                JoinEventId = joinevents.JoinEventId,
                JoinEventStatus = joinevents.JoinEventStatus,
                EventId = joinevents.EventId,
                UserId = joinevents.UserId,
                Description = joinevents.Description,
                CreatedBy = joinevents.CreatedBy,
            };
            return vJoinevent;*/
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
