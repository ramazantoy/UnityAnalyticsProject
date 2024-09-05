namespace UnityAnalytics.Back.Core.Domain;

public class CustomEvent 
{
    public string EventName { get; set; }
    public string EventData { get; set; }
    public DateTime EventTime { get; set; }
    public int GameId { get; set; }
    public Game Game { get; set; }
}