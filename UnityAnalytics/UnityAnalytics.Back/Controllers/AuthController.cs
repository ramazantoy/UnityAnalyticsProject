using MediatR;
using Microsoft.AspNetCore.Mvc;
using UnityAnalytics.Back.Core.Application.CQRS.Commands;
using UnityAnalytics.Back.Core.Application.CQRS.Queries;
using UnityAnalytics.Back.Infrastructure;

namespace UnityAnalytics.Back.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost("[action]")]
    public async Task<IActionResult> Register(RegisterUserCommandRequest request)
    {
       var response= await _mediator.Send(request);
       if (response.IsSuccess)
       {
           return Created("",  JwtTokenGenerator.GenerateToken(response));
       }

       return BadRequest(response.ErrorMessage);
    }
    
    [HttpPost("[action]")]
    public async Task<IActionResult> Login(CheckUserQueryRequest request)
    {
        var dto = await _mediator.Send(request);
        if (dto.IsExist)
        {
         return Created("", JwtTokenGenerator.GenerateToken(dto));
        }

        return BadRequest(dto.ErrorMessage);
    }
}