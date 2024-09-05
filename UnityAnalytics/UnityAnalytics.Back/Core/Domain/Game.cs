namespace UnityAnalytics.Back.Core.Domain;

public class Game 
{
    public string GameId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }=DateTime.Now;
    public AppUser User { get; set; }
    public string UserId { get; set; }
    public ICollection<GameStats> GameStats { get; set; }
    public ICollection<CustomEvent> CustomEvents { get; set; }
}