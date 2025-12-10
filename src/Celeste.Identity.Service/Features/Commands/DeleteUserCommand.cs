namespace Celeste.Identity.Application.Features.Commands;

using MediatR;

/// <summary>
///     Delete user command.
/// </summary>
/// <param name="UserId"></param>
public record DeleteUserCommand(Guid UserId) : IRequest;
