namespace CallCentreOperations.Models
{
    public class Agent
    {
        public int Id { get; set; }
        public string AgentName { get; set; }
        public string AgentState { get; set; }
        public DateTime TimestampUtc { get; set; }
        public string[] Skills { get; set; }
    }
}
