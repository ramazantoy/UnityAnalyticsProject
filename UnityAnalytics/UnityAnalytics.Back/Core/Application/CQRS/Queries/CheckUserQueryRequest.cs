﻿using MediatR;
using UnityAnalytics.Back.Core.Application.Dto;

namespace UnityAnalytics.Back.Core.Application.CQRS.Queries;

public class CheckUserQueryRequest : IRequest<CheckUserDto>
{
    public string UserName { get; set; } = null!;
    public string Password { get; set; } = null!;
    
}