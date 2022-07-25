using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedObjects.ViewModels
{
    public class PrizeViewModel
    {
        public string PrizeId { get; set; }
        public string PrizeName { get; set; }
        public string Content { get; set; }
        public int Amount { get; set; }
        public int Distributed { get; set; }
        public int Status { get; set; }
        public string EventId { get; set; }
        public string CreatedBy { get; set; }
    }
}
