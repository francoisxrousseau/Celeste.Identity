namespace Celeste.Identity.Application.Features.Queries;

using Celeste.Identity.Common.Responses;
using MediatR;
using System;

/// <summary>
///     Get user query.
/// </summary>
/// <param name="UserId"></param>
public record GetUserQuery(Guid UserId) : IRequest<UserResponse>;
