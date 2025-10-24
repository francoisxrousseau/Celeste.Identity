namespace Celeste.Identity.Api.Controllers;

using Celeste.Identity.Application.Features.Commands;
using Celeste.Identity.Application.Features.Queries;
using Celeste.Identity.Common.Models;
using Celeste.Identity.Common.Parameters;
using Celeste.Identity.Common.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

/// <summary>
///     The users controller handles user-related HTTP requests.
/// </summary>
[ApiController]
[Route("users")]
public class UsersController(IMediator mediator) : ControllerBase
{
    readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

    /// <summary>
    ///     Get a specific user by id.
    /// </summary>
    /// <param name="parameters"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [HttpGet]
    public async Task<ActionResult<UserResponse>> GetUser(
        [FromQuery]GetUserParameters parameters,
        CancellationToken cancellationToken)
    {
        var users = await _mediator.Send(new GetUserQuery(parameters.UserId), cancellationToken);
        return Ok(users);
    }

    /// <summary>
    ///     Get a specific user by id.
    /// </summary>
    /// <param name="parameters"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [ProducesResponseType(typeof(UserResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
    [HttpPost]
    public async Task<ActionResult<UserResponse>> CreateUser(
        [FromBody] CreateUserModel parameters,
        CancellationToken cancellationToken)
    {
        var users = await _mediator.Send(new CreateUserCommand(parameters.UserName, parameters.Email, parameters.Password), cancellationToken);
        return Ok(users);
    }
}
