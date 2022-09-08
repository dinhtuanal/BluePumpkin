namespace App.Models
{
    public class EventModel
    {
        public EventModel() { }
        public EventModel(string eventId, string eventName, string eventStatus, string title, string imgUrl, string content, string jointEventStatus, DateTime timeStart, DateTime timeEnd, string createdBy)
        {
            this.EventId = eventId;
            this.EventName = eventName;
            this.EventStatus = eventStatus;
            this.Title = title;
            this.ImgUrl = imgUrl;
            this.Content = content;
            this.TimeStart = timeStart;
            this.TimeEnd = timeEnd;
            this.CreatedBy = createdBy;
            this.jointEventStatus = jointEventStatus;
        }

        public string EventId { get; set; }
        public string EventName { get; set; }
        public string EventStatus { get; set; }
        public string Title { get; set; }
        public string ImgUrl { get; set; }
        public string Content { get; set; }
        public string jointEventStatus { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public string CreatedBy { get; set; }
    }
}
