using MediatR;
using Microsoft.AspNetCore.Mvc;
using UnityAnalytics.Back.Core.Application.CQRS.Commands;
using UnityAnalytics.Back.Core.Application.CQRS.Queries;
using UnityAnalytics.Back.Infrastructure;

namespace UnityAnalytics.Back.Controllers;

[Route("api/[controller]")]

public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost("Register")]
    public async Task<IActionResult> Register(RegisterUserCommandRequest request)
    {
        await _mediator.Send(request);
        return Created("", request);
    }
    
    [HttpPost("[action]")]
    public async Task<IActionResult> Login(CheckUserQueryRequest request)
    {
        var dto = await _mediator.Send(request);
        if (dto.IsExist)
        {
         return Created("", JwtTokenGenerator.GenerateToken(dto));
        }

        return BadRequest("username or password is wrong");
    }
}