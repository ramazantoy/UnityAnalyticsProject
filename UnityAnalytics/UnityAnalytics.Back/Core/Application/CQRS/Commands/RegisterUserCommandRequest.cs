using MediatR;

namespace UnityAnalytics.Back.Core.Application.CQRS.Commands;

public class RegisterUserCommandRequest : IRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
}