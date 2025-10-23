namespace Celeste.Identity.Data.Repositories;

using AutoMapper;
using Celeste.Identity.Core.Domain;
using Celeste.Identity.Core.Repositories;
using Celeste.Identity.Data.Documents;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading;
using System.Threading.Tasks;

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
        CancellationToken cancellationToken)
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
        CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(id.ToString());

        var domainUser = _mapper.Map<User>(user);

        return domainUser;
    }

    /// <inheritdoc/> 
    public async Task<Guid> CreateAsync(
        User user, 
        CancellationToken cancellationToken)
    {
        if (user == null)
            throw new ArgumentNullException(nameof(user));

        var userDocument = _mapper.Map<UserDocument>(user);

        var result = await _userManager.CreateAsync(userDocument);

        if (result.Errors.Any())
            throw new InvalidOperationException($"Failed to create user: {string.Join(", ", result.Errors.Select(e => e.Description))}");

        return userDocument.Id;
    }

}
