using MediatR;
using Microsoft.AspNetCore.Mvc;
using UnityAnalytics.Back.Core.Application.CQRS.Commands;

namespace UnityAnalytics.Back.Controllers;

[Route("api/[controller]")]
public class GameController : ControllerBase
{
    private readonly IMediator _mediator;

    public GameController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> CreateGame(CreateGameCommandRequest request)
    {
        var result = await _mediator.Send(request);

        if (result.IsSuccess)
        {
            return Ok(result);
        }

        return BadRequest(request);
    }
}