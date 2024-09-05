namespace UnityAnalytics.Back.Core.Domain;

public class AppUser
{
    public Guid Id { get; set; }
    public string? UserName { get; set; }
    public string? Password { get; set; }
    public int AppRoleId { get; set; }
    public AppRole? AppRole { get; set; }
}