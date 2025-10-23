namespace Celeste.Identity.Core.Repositories;

using Celeste.Identity.Core.Domain;

/// <summary>
///     The user repository interface.
///     Exposes all the interactions possible with the identity user store.
/// </summary>
public interface IUserRepository
{
    /// <summary>
    ///     Gets a user by its unique identifier.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<User> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken);

    /// <summary>
    ///     Gets a user by its unique email.
    /// </summary>
    /// <param name="email"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<User> GetByEmailAsync(
        string email,
        CancellationToken cancellationToken);

    /// <summary>
    ///     Create the specified user.
    /// </summary>
    /// <param name="user"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<Guid> CreateAsync(
        User user,
        CancellationToken cancellationToken);
}