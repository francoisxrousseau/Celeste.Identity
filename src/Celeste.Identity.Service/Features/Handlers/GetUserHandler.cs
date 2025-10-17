namespace Celeste.Identity.Application.Features.Handlers;

using Celeste.Identity.Application.Exceptions;
using Celeste.Identity.Application.Features.Queries;
using Celeste.Identity.Common.Responses;
using Celeste.Identity.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
///     The query handler for <see cref="GetUserQuery"/>.
/// </summary>
public class GetUserHandler : IRequestHandler<GetUserQuery, UserResponse>
{
    private readonly IUserRepository _userRepository;

    /// <summary>
    /// </summary>
    /// <param name="userRepository"></param>
    public GetUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
    }

    /// <summary>
    ///     Handles the <see cref="GetUserQuery"/> request.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="NotFoundException"></exception>
    public Task<UserResponse> Handle(
        GetUserQuery request,
        CancellationToken cancellationToken)
    {
        _ = request ?? throw new ArgumentNullException(nameof(request));

        var user = _userRepository.GetById(request.UserId, cancellationToken);

        if (user == null)
            throw new NotFoundException(nameof(request.UserId), request.UserId.ToString());

        //TODO : Map User domain model to UserResponse

        return Task.FromResult(new UserResponse());
    }
}
