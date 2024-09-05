namespace UnityAnalytics.Back.Core.Domain;

public class AppUser
{
    public int UserId { get; set; }
    public string? UserName { get; set; }
    public string? Password { get; set; }
    public int AppRoleId { get; set; }
    public AppRole? AppRole { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}