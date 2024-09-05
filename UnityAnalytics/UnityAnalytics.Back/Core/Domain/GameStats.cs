namespace UnityAnalytics.Back.Core.Domain;

public class GameStats : EntityBase
{
    public int TotalPlays { get; set; }
    public int UniqueUsers { get; set; }
    public double AveragePlayTime { get; set; }
    public Guid GameId { get; set; }
    public Game Game { get; set; }
}