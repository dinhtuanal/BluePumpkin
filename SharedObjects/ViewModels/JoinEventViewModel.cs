using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedObjects.ViewModels
{
    public class JoinEventViewModel
    {
        public string JoinEventId { get; set; }
        public int JoinEventStatus { get; set; }
        public string EventId { get; set; }
        public string UserId { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
    }
}
