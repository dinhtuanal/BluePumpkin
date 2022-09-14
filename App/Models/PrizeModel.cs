using SharedObjects.Commons;

namespace App.Models
{
    public class PrizeModel
    {
        public Guid PrizeId { get; set; }
        public string PrizeName { get; set; }
        public string Content { get; set; }
        public int Amount { get; set; }
        public int Distributed { get; set; }
        public Status Status { get; set; }
        public Guid? EventId { get; set; }
        public string EventName { get; set; }
        public string CreatedBy { get; set; }
    }
}
