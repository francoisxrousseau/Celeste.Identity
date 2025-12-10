namespace Celeste.Identity.Core.Repositories;

using Celeste.Identity.Common.Parameters;
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
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Gets a user by its unique email.
    /// </summary>
    /// <param name="email"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<User> GetByEmailAsync(
        string email,
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Gets users with pagination, search and sorting.
    /// </summary>
    /// <param name="limit"></param>
    /// <param name="offset"></param>
    /// <param name="searchTerm"></param>
    /// <param name="sortField"></param>
    /// <param name="sortDirection"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<User> GetAsync(
        int offset = 0,
        int limit = 100,
        string searchTerm = null,
        UsersSortField sortField = UsersSortField.UserName,
        SortDirection sortDirection = SortDirection.Asc,
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Create the specified user.
    /// </summary>
    /// <param name="user"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<Guid> CreateAsync(
        User user,
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Delete the specified user.
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<bool> DeleteAsync(
        Guid userId,
        CancellationToken cancellationToken = default);
}