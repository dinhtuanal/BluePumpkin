using SharedObjects.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class JoinEvent
    {
        public Guid JoinEventId { get; set; }
        public JoinEventStatus JoinEventStatus { get; set; }
        public Guid EventId { get; set; }
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public Event Event { get; set; }
    }
}
