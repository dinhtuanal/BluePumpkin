using SharedObjects.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedObjects.ValueObjects
{
    public class VJoinEvent
    {
        public Guid JoinEventId { get; set; }
        public JoinEventStatus JoinEventStatus { get; set; }
        public Guid? EventId { get; set; }
        public string EventName { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
    }
}
