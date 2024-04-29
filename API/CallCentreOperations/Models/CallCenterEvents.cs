namespace CallCentreOperations.Models
{
    public class CallCenterEvents
    {
        public int AgentId { get; set; }
        public string AgentName { get; set; } = string.Empty;
        public DateTime TimestampUtc { get; set; }
        public string Action { get; set; } = string.Empty;
        public string[] QueueIds { get; set; } = new string[0];
    }
}
