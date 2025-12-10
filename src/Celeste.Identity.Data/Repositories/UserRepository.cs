namespace Celeste.Identity.Data.Repositories;

using AutoMapper;
using Celeste.Identity.Common.Parameters;
using Celeste.Identity.Core.Domain;
using Celeste.Identity.Core.Repositories;
using Celeste.Identity.Data.Documents;
using Microsoft.AspNetCore.Identity;
using MongoDB.Driver;
using System;
using System.Threading;
using System.Threading.Tasks;
using SortDirection = Common.Parameters.SortDirection;

/// <inheritdoc/> 
public class UserRepository(
    UserManager<UserDocument> userManager,
    IMapper mapper) 
    : IUserRepository
{
    private readonly UserManager<UserDocument> _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
    private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

    /// <inheritdoc/> 
    public async Task<User> GetByEmailAsync(
        string email,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentNullException(nameof(email));

        var user = await _userManager.FindByEmailAsync(email);

        var domainUser = _mapper.Map<User>(user);

        return domainUser;
    }

    /// <inheritdoc/> 
    public async Task<User> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        var user = await _userManager.FindByIdAsync(id.ToString());

        var domainUser = _mapper.Map<User>(user);

        return domainUser;
    }

    public async Task<User> GetAsync(
        int offset,
        int limit,
        string searchTerm,
        UsersSortField sortField,
        SortDirection sortDirection,
        CancellationToken cancellationToken = default)
    {
        var query = _userManager.Users.AsQueryable();

        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            query = query.Where(u => u.UserName.Contains(searchTerm));
        }

        return null;
    }

    /// <inheritdoc/> 
    public async Task<Guid> CreateAsync(
        User user, 
        CancellationToken cancellationToken = default)
    {
        if (user == null)
            throw new ArgumentNullException(nameof(user));

        var userDocument = _mapper.Map<UserDocument>(user);

        var result = await _userManager.CreateAsync(userDocument, user.Password);

        if (result.Errors.Any())
            throw new InvalidOperationException($"Failed to create user: {string.Join(", ", result.Errors.Select(e => e.Description))}");

        return userDocument.Id;
    }

    /// <inheritdoc/> 
    public async Task<bool> DeleteAsync(
        Guid userId,
        CancellationToken cancellationToken = default)
    {
        // Limitation with UserManager implemented with MongoDb, we have to first find the user then delete it without mapping
        // to domain object first since it would lose the connection with the UserManager.
        // There is not calls concurency risk here since this is identity management operations managed by UserManager itself.
        var user = await _userManager.FindByIdAsync(userId.ToString());

        if (user == null)
            return false;

        var result = await _userManager.DeleteAsync(user);

        if (result.Errors.Any())
            throw new InvalidOperationException($"Failed to create user: {string.Join(", ", result.Errors.Select(e => e.Description))}");

        return true;
    }
}
