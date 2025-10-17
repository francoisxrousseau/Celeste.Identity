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
    Task<User> GetById(
        Guid id,
        CancellationToken cancellationToken);
}
