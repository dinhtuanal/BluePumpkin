using SharedObjects.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class PrizeDistribution
    {
        public Guid PrizeDistributionId { get; set; }
        public Status Status { get; set; }
        public Guid? JoinEventId { get; set; }
        public JoinEvent JoinEvent { get; set; }
        public Guid? PrizeId { get; set; }
        public int Ranking { get; set; }
        public int Amount { get; set; }
        public string CreatedBy { get; set; }
    }
}
