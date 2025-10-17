namespace Celeste.Identity.Data.Documents;

using AspNetCore.Identity.MongoDbCore.Models;
using MongoDbGenericRepository.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
///     The User document.
/// </summary>
[CollectionName("users")]
public class UserDocument : MongoIdentityUser<Guid>
{
    /// <summary>
    ///     The creation date.
    /// </summary>
    public DateTime CreationDate { get; set; }

    /// <summary>
    ///  The last login date.
    /// </summary>
    public DateTime LastLoginDate { get; set; }

    /// <summary>
    ///  The deletion date.
    /// </summary>
    public DateTime? DeletionDate { get; set; }
}

