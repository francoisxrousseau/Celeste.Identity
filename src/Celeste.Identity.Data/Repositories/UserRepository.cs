namespace Celeste.Identity.Data.Repositories;

using Celeste.Identity.Core.Domain;
using Celeste.Identity.Core.Repositories;
using Celeste.Identity.Data.Documents;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/// <inheritdoc/> 
public class UserRepository : IUserRepository
{
    private readonly UserManager<UserDocument> _userManager;

    public UserRepository(UserManager<UserDocument> userManager)
    {
        _userManager = userManager;
    }

    /// <inheritdoc/> 
    public async Task<User> GetById(
        Guid id,
        CancellationToken cancellationToken)
    {
        var user = await  _userManager.FindByIdAsync(id.ToString());
        
        //TODO : Map UserDocument to User domain model

        return new User();
    }
}
