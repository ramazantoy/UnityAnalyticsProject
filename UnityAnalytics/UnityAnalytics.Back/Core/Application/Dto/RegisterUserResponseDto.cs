namespace UnityAnalytics.Back.Core.Application.Dto;

public class RegisterUserResponseDto : UserDto
{
    public string ErrorMessage { get; set; } = string.Empty;
    public bool IsSuccess { get; set; } = false;

    public TokenResponseDto TokenResponseDto { get; set; } = null!;
}