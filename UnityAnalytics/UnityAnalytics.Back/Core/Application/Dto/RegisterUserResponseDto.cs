namespace UnityAnalytics.Back.Core.Application.Dto;

public class RegisterUserResponseDto
{
    public string Username { get; set; } = string.Empty;
    public string ErrorMessage { get; set; } = string.Empty;
    public bool IsSuccess { get; set; } = false;
}