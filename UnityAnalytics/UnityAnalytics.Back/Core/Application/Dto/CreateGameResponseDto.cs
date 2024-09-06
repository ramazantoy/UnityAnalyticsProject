namespace UnityAnalytics.Back.Core.Application.Dto;

public class CreateGameResponseDto
{
    public string GameName { get; set; }
    public Guid GameId { get; set; }
    public bool IsSuccess { get; set; }
}