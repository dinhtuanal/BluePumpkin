using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedObjects.ViewModels
{
    public class PrizeDistributionViewModel
    {
        public string PrizeDistributionId { get; set; }
        public int Status { get; set; }
        public string JoinEventId { get; set; }
        public string PrizeId { get; set; }
        public int Ranking { get; set; }
        public int Amount { get; set; }
        public string CreatedBy { get; set; }
    }
}
