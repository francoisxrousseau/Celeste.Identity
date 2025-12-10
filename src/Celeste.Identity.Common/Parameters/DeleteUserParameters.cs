namespace Celeste.Identity.Common.Parameters;

using System;

/// <summary>
///     Includes the http request parameters for deleting a user.
/// </summary>
public record DeleteUserParameters(Guid UserId);
