namespace UnityAnalytics.Back.Core.Domain;

public class CustomEvent : EntityBase
{
    public string EventName { get; set; }
    public string EventData { get; set; }
    public DateTime EventTime { get; set; }
    public Guid GameId { get; set; } 
    public Game Game { get; set; }
}