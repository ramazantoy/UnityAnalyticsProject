﻿using MediatR;
using UnityAnalytics.Back.Core.Application.Dto;

namespace UnityAnalytics.Back.Core.Application.CQRS.Commands;

public class RegisterUserCommandRequest : IRequest<RegisterUserResponseDto>
{
    public string Username { get; set; }
    public string Password { get; set; }
}