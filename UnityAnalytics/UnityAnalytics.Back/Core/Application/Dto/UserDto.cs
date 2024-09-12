namespace UnityAnalytics.Back.Core.Application.Dto;

public  abstract class UserDto
{
    public Guid Id { get; set; }
    public string? Username { get; set; }
    public  string? Role { get; set; }
}