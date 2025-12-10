namespace Celeste.Identity.Application.Features.Handlers;

using Celeste.Identity.Application.Exceptions;
using Celeste.Identity.Application.Features.Commands;
using Celeste.Identity.Core.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
///     The command handler for <see cref="DeleteUserCommand"/>.
/// </summary>
public class DeleteUserHandler(
    IUserRepository userRepository) 
    : IRequestHandler<DeleteUserCommand>
{
    private readonly IUserRepository _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));

    /// <summary>
    ///     Handles the <see cref="DeleteUserCommand"/> request.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public async Task Handle(
        DeleteUserCommand request,
        CancellationToken cancellationToken)
    {
        _ = request ?? throw new ArgumentNullException(nameof(request));

        var result = await _userRepository.DeleteAsync(request.UserId, cancellationToken);

        if (!result)
            throw new NotFoundException(nameof(request.UserId), request.UserId.ToString());
    }
}
