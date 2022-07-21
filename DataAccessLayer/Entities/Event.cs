using SharedObjects.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Event
    {
        public Event()
        {
            JoinEvents = new HashSet<JoinEvent>();
            Prizes= new HashSet<Prize>();
        }
        public Guid EventId { get; set; }
        public string EventName { get; set; }
        public EventStatus EventStatus { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public string CreatedBy { get; set; }
        public virtual ICollection<JoinEvent> JoinEvents { get; set; }
        public virtual ICollection<Prize> Prizes { get; set; }
    }
}
