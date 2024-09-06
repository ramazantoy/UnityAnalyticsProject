using MediatR;
using UnityAnalytics.Back.Core.Application.CQRS.Commands;
using UnityAnalytics.Back.Core.Application.Enums;
using UnityAnalytics.Back.Core.Application.Interfaces;
using UnityAnalytics.Back.Core.Domain;

namespace UnityAnalytics.Back.Core.Application.CQRS.Handlers;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommandRequest>
{
    private readonly IRepository<AppUser> _repository;

    public RegisterUserCommandHandler(IRepository<AppUser> repository)
    {
        _repository = repository;
    }
    


    public async Task<Unit> Handle(RegisterUserCommandRequest request, CancellationToken cancellationToken)
    {
        await _repository.CreateAsync(new AppUser()
        {
            UserName = request.Username,
            Password = request.Password,
            AppRoleId = (int)RoleType.Member,
        });
        return  Unit.Value;
    }
}

   