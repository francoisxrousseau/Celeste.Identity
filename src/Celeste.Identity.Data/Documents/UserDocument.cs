namespace Celeste.Identity.Data.Documents;

using AspNetCore.Identity.MongoDbCore.Models;
using MongoDbGenericRepository.Attributes;
using System;

/// <summary>
///     The User document.
/// </summary>
[CollectionName("users")]
public class UserDocument : MongoIdentityUser<Guid>
{
    /// <summary>
    ///  The last login date.
    /// </summary>
    public DateTime LastLoginDate { get; set; }

    /// <summary>
    ///  The deletion date.
    /// </summary>
    public DateTime? DeletionDate { get; set; }
}

