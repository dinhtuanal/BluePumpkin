using SharedObjects.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedObjects.ValueObjects
{
    public class VPrizeDistribution
    {
        public Guid PrizeDistributionId { get; set; }
        public Status Status { get; set; }
        public Guid? JoinEventId { get; set; }
        public Guid? PrizeId { get; set; }
        public int Ranking { get; set; }
        public int Amount { get; set; }
        public string CreatedBy { get; set; }
    }
}
