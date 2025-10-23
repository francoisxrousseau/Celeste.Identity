namespace Celeste.Identity.Application.Features.Handlers;

using AutoMapper;
using Celeste.Identity.Application.Exceptions;
using Celeste.Identity.Application.Features.Commands;
using Celeste.Identity.Application.Features.Queries;
using Celeste.Identity.Core.Domain;
using Celeste.Identity.Core.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
///     The query handler for <see cref="GetUserQuery"/>.
/// </summary>
public class CreateUserHandler(
    IUserRepository userRepository,
    IMapper mapper) 
    : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly IUserRepository _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
    private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

    /// <summary>
    ///     Handles the <see cref="CreateUserCommand"/> request.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public async Task<Guid> Handle(
        CreateUserCommand request,
        CancellationToken cancellationToken)
    {
        _ = request ?? throw new ArgumentNullException(nameof(request));

        if (await _userRepository.GetByEmailAsync(request.Email, cancellationToken) != null)
            throw new ConflictException("The user with the specified email already exists", nameof(request.Email), request.Email);

        var user = _mapper.Map<User>(request);

        var userId = await _userRepository.CreateAsync(user, cancellationToken);

        return userId;
    }
}
