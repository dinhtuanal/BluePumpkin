namespace App.Models
{
    public class EventModel
    {
        public EventModel() { }
        public EventModel(string eventId, string eventName, string eventStatus, string title, string imgUrl, string content, DateTime timeStart, DateTime timeEnd, string createdBy)
        {
            EventId = eventId;
            EventName = eventName;
            EventStatus = eventStatus;
            Title = title;
            ImgUrl = imgUrl;
            Content = content;
            TimeStart = timeStart;
            TimeEnd = timeEnd;
            CreatedBy = createdBy;
        }

        public string EventId { get; set; }
        public string EventName { get; set; }
        public string EventStatus { get; set; }
        public string Title { get; set; }
        public string ImgUrl { get; set; }
        public string Content { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public string CreatedBy { get; set; }
    }
}
