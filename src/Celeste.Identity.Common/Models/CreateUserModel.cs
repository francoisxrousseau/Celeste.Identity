namespace Celeste.Identity.Common.Models;

/// <summary>
///     The create user model.
/// </summary>
/// <param name="Email"></param>
/// <param name="Password"></param>
public record CreateUserModel(
    string Email,
    string Password);