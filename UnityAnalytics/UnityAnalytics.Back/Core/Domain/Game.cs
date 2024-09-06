namespace UnityAnalytics.Back.Core.Domain;

public class Game : EntityBase
{
    public string Name { get; set; }
    public Guid UserId { get; set; } 
    public AppUser? AppUser { get; set; }
    public ICollection<GameStats> GameStats { get; set; }
    public ICollection<CustomEvent> CustomEvents { get; set; }
}