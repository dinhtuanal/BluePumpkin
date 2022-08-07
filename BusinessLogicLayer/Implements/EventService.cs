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
    public class EventService : IEventService
    {
        private readonly BluePumpkinDbContext _context;
        public EventService(BluePumpkinDbContext context)
        {
            _context = context;
        }
        public async Task<int> Add(EventViewModel model)
        {
            var newEvent = new Event()
            {
                EventId = Guid.NewGuid(),
                EventName = model.EventName,
                EventStatus = (EventStatus)model.EventStatus,
                Title = model.Title,
                ImgUrl = model.ImgUrl,
                Content = model.Content,
                TimeStart = model.TimeStart,
                TimeEnd = model.TimeEnd,
                CreatedBy = model.CreatedBy,
            };
            _context.Events.Add(newEvent);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(string id)
        {
            var eventById = await _context.Events.FindAsync(Guid.Parse(id));
            if (eventById == null)
            {
                throw new CustomException("Can not find event id", 404);
            }
            _context.Events.Remove(eventById);
            return await _context.SaveChangesAsync();
        }

        public List<VEvent> GetAll()
        {
            var events = _context.Events.ToList();
            var vEvents = events.ConvertAll(x => new VEvent
            {
                EventId = x.EventId,
                EventName = x.EventName,
                Title = x.Title,
                Content = x.Content,
                ImgUrl = x.ImgUrl,
                EventStatus = x.EventStatus,
                CreatedBy = x.CreatedBy,
                TimeStart = x.TimeStart,
                TimeEnd= x.TimeEnd,
            });
            return vEvents.OrderByDescending(x=>x.TimeStart).OrderByDescending(x=>x.EventStatus).ToList();
        }

        public async Task<VEvent> GetById(string id)
        {
            var eventById = await _context.Events.FindAsync(Guid.Parse(id));
            if (eventById == null)
            {
                throw new CustomException("Can not find event id", 404);
            }
            var vEvent = new VEvent
            {
                EventId = eventById.EventId,
                EventName = eventById.EventName,
                Title = eventById.Title,
                Content = eventById.Content,
                EventStatus = eventById.EventStatus,
                CreatedBy = eventById.CreatedBy,
                TimeStart = eventById.TimeStart,
                TimeEnd = eventById.TimeEnd,
            };
            return vEvent;
        }

        public async Task<int> Update(EventViewModel model)
        {
            var eventById = await _context.Events.FindAsync(Guid.Parse(model.EventId));
            if (eventById == null)
            {
                throw new CustomException("Can not find event id", 404);
            }
            eventById.EventName = model.EventName;
            eventById.Title = model.Title;
            eventById.EventStatus = (EventStatus)model.EventStatus;
            eventById.Content = model.Content;
            eventById.TimeStart = model.TimeStart;
            eventById.TimeEnd = model.TimeEnd;
            _context.Events.Update(eventById);
            return _context.SaveChanges();
        }
    }
}
