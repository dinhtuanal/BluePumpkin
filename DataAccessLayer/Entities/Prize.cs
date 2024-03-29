﻿using SharedObjects.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Prize
    {
        public Guid PrizeId { get; set; }
        public string PrizeName { get; set; }
        public string Content { get; set; }
        public int Amount { get; set; }
        public int Distributed { get; set; }
        public Status Status { get; set; }
        public Guid? EventId { get; set; }
        public Event Event { get; set; }
        public string CreatedBy { get; set; }
    }
}
