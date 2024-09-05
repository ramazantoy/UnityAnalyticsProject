namespace UnityAnalytics.Back.Core.Domain;

public class Game : EntityBase
{
    public Guid GameId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid UserId { get; set; } 
    public AppUser? AppUser { get; set; }
    public ICollection<GameStats> GameStats { get; set; }
    public ICollection<CustomEvent> CustomEvents { get; set; }
}