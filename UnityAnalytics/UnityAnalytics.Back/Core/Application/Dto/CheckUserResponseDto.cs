namespace UnityAnalytics.Back.Core.Application.Dto;

public class CheckUserResponseDto
{
    public Guid Id { get; set; }
    public string? Username { get; set; }
    public string? Role { get; set; }
    public bool IsExist { get; set; }
    public string ErrorMessage { get; set; } = string.Empty;
}