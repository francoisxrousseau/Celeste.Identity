namespace Celeste.Identity.Application.Features.Handlers;

using AutoMapper;
using Celeste.Identity.Application.Exceptions;
using Celeste.Identity.Application.Features.Queries;
using Celeste.Identity.Common.Responses;
using Celeste.Identity.Core.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
///     The query handler for <see cref="GetUserQuery"/>.
/// </summary>
public class GetUserHandler(
    IUserRepository userRepository,
    IMapper mapper)
    : IRequestHandler<GetUserQuery, UserResponse>
{
    private readonly IUserRepository _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
    private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

    /// <summary>
    ///     Handles the <see cref="GetUserQuery"/> request.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="NotFoundException"></exception>
    public async Task<UserResponse> Handle(
        GetUserQuery request,
        CancellationToken cancellationToken)
    {
        _ = request ?? throw new ArgumentNullException(nameof(request));

       var user = await _userRepository.GetByIdAsync(request.UserId, cancellationToken);

        if (user == null)
            throw new NotFoundException(nameof(request.UserId), request.UserId.ToString());

        var userResponse = _mapper.Map<UserResponse>(user);

        return userResponse;
    }
}
