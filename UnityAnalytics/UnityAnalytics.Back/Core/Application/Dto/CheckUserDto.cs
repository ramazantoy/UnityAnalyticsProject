namespace UnityAnalytics.Back.Core.Application.Dto;

public class CheckUserDto : UserDto
{
    public bool IsExist { get; set; }
    public string ErrorMessage { get; set; } = string.Empty;
}