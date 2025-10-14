namespace Celeste.Identity.Data.Repositories;

using Celeste.Identity.Common.Repositories;
using Celeste.Identity.Data.Documents;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <inheritdoc/> 
public class UserRepository : IUserRepository
{
    private readonly UserManager<User> _userManager;

    public UserRepository(UserManager<User> userManager)
    {
        _userManager = userManager;
    }
}
