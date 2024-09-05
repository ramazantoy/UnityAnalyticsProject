namespace UnityAnalytics.Back.Core.Domain;

public  abstract class EntityBase
{
    public Guid Id { get; set; }=Guid.NewGuid();
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}