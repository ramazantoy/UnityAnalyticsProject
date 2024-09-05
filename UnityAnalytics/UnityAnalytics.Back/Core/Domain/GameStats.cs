namespace UnityAnalytics.Back.Core.Domain;

public class GameStats 
{
    public string Region { get; set; }
    public TimeSpan PlayTime { get; set; }
    public int GamePlayerId { get; set; }
    public GamePlayer? Player { get; set; }
    public int GameId { get; set; }
    public Game Game { get; set; }
}