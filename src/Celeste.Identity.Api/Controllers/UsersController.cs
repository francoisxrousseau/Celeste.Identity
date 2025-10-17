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

    /// <summary>
    ///     Get a specific user by id.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<UserResponse>> GetUser(Guid id, CancellationToken cancellationToken)
    {
        var users = await _mediator.Send(new GetUserQuery(id), cancellationToken);
        return Ok(users);
    }
}
