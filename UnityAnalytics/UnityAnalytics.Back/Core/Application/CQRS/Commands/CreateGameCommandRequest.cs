using MediatR;
using UnityAnalytics.Back.Core.Application.Dto;

namespace UnityAnalytics.Back.Core.Application.CQRS.Commands;

public class CreateGameCommandRequest : IRequest<CreateGameResponseDto>
{
    public Guid UserId { get; set; }
    public string GameName { get; set; }
}