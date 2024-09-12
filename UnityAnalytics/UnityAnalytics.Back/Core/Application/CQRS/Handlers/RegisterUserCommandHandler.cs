using MediatR;
using Microsoft.AspNetCore.Identity;
using UnityAnalytics.Back.Core.Application.CQRS.Commands;
using UnityAnalytics.Back.Core.Application.Dto;
using UnityAnalytics.Back.Core.Application.Enums;
using UnityAnalytics.Back.Core.Application.Interfaces;
using UnityAnalytics.Back.Core.Domain;

namespace UnityAnalytics.Back.Core.Application.CQRS.Handlers;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommandRequest,RegisterUserResponseDto>
{
    private readonly IRepository<AppUser> _repository;

    public RegisterUserCommandHandler(IRepository<AppUser> repository)
    {
        _repository = repository;
    }
    


    public async Task<RegisterUserResponseDto> Handle(RegisterUserCommandRequest request, CancellationToken cancellationToken)
    {
        var isExist = await _repository.AnyAsync(x => x.UserName == request.Username);
    
        if (isExist)
        {
            return new RegisterUserResponseDto
            {
                IsSuccess = false,
                ErrorMessage = "Username already exists!",
                Username = request.Username,
            };
        }

        var passwordHasher = new PasswordHasher<AppUser>();
        var hashedPassword = passwordHasher.HashPassword(null!, request.Password);

        var user = new AppUser
        {
            UserName = request.Username,
            Password = hashedPassword,
            AppRoleId = (int)RoleType.Member
        };

        await _repository.CreateAsync(user);

        return new RegisterUserResponseDto
        {
            IsSuccess = true,
            Username = request.Username
        };
    }
}

   