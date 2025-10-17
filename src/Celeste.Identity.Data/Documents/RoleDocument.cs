namespace Celeste.Identity.Data.Documents;

using AspNetCore.Identity.MongoDbCore.Models;
using MongoDbGenericRepository.Attributes;
using System;

/// <summary>
///     The Role document.
/// </summary>
[CollectionName("roles")]
public class RoleDocument : MongoIdentityRole<Guid>
{

}

