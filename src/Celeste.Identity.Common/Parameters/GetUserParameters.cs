namespace Celeste.Identity.Common.Parameters;

using System;

/// <summary>
///     Includes the http request parameters for getting a user.
/// </summary>
public class GetUserParameters
{
    public Guid UserId { get; set; }
}
