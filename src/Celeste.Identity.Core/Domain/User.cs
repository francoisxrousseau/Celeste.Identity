namespace Celeste.Identity.Core.Domain;

/// <summary>
///     Represents the User domain object.
/// </summary>
public class User
{
    /// <summary>
    ///     The username of the user.
    /// </summary>
    public string UserName { get; set; }

    /// <summary>
    ///     The email of the user.
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    ///     The password of the user.
    /// </summary>
    public string Password { get; set; }
}
