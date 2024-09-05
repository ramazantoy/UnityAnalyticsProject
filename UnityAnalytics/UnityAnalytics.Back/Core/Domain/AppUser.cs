namespace UnityAnalytics.Back.Core.Domain;

public class AppUser : EntityBase
{
    public string? UserName { get; set; }
    public string? Password { get; set; }
    public int AppRoleId { get; set; }

    public AppRole? AppRole { get; set; }
    public ICollection<Game> Games { get; set; }

 
}