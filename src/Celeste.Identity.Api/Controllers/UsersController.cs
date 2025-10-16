namespace Celeste.Identity.Api.Controllers;

using Celeste.Identity.Application.Features.Queries;
using Celeste.Identity.Common.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

/// <summary>
///     The users controller.
/// </summary>
[ApiController]
[Route("users")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserResponse>> GetUser(Guid id, CancellationToken cancellationToken)
    {
        var users = await _mediator.Send(new GetUserQuery(id), cancellationToken);
        return Ok(users);
    }
}
