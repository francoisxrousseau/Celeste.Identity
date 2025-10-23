namespace Celeste.Identity.Common.Parameters;

using System;

/// <summary>
///     Includes the http request parameters for getting a user.
/// </summary>
public record GetUserParameters(Guid UserId);
