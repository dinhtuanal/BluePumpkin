namespace App.Models
{
    public class JoinEvent
    {
        public JoinEvent() { }
        public string JoinEventId { get; set; }
        public string JoinEventStatus { get; set; }
        public string EventId { get; set; }
        public string EventName { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Eescription { get; set; }
        public string CreatedBy { get; set; }
    }
}
