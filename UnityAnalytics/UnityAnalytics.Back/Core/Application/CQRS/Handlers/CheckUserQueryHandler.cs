using MediatR;
using Microsoft.AspNetCore.Identity;
using UnityAnalytics.Back.Core.Application.CQRS.Queries;
using UnityAnalytics.Back.Core.Application.Dto;
using UnityAnalytics.Back.Core.Application.Interfaces;
using UnityAnalytics.Back.Core.Domain;

namespace UnityAnalytics.Back.Core.Application.CQRS.Handlers;

public class CheckUserQueryHandler : IRequestHandler<CheckUserQueryRequest, CheckUserResponseDto>
{
    private readonly IRepository<AppUser> _userRepository;
    private readonly IRepository<AppRole> _roleRepository;
  

    public CheckUserQueryHandler(IRepository<AppUser> userRepository, IRepository<AppRole> roleRepository)
    {
        _userRepository = userRepository;
        _roleRepository = roleRepository;
    }

    public async Task<CheckUserResponseDto> Handle(CheckUserQueryRequest request, CancellationToken token)
    {
        var dto = new CheckUserResponseDto();
        var passwordHasher = new PasswordHasher<AppUser>();

        var user = await _userRepository.GetByFilter(x => x.UserName == request.UserName);

        if (user == null)
        {
            dto.IsExist = false;
            dto.ErrorMessage = "User does not exist";
        }
        else
        {
            var result = passwordHasher.VerifyHashedPassword(user, user.Password, request.Password);

            if (result == PasswordVerificationResult.Success)
            {
                dto.Username = user.UserName;
                dto.Id = user.Id;
                dto.IsExist = true;

                var role = await _roleRepository.GetByFilter(x => x.Id == user.AppRoleId);
                dto.Role = role?.Definition;
            }
            else
            {
                dto.IsExist = false;
                dto.ErrorMessage = "Invalid password";
            }
        }

        return dto;
    }

  
}

  