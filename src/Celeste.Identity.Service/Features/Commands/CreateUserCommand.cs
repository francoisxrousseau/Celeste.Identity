namespace Celeste.Identity.Application.Features.Commands;

using MediatR;

/// <summary>
///     Create user command.
/// </summary>
/// <param name="Email"></param>
/// <param name="Password"></param>
public record CreateUserCommand(string Email, string Password) : IRequest<Guid>;
