namespace Celeste.Identity.Application.Exceptions;

using System;

/// <summary>
///     Custom exception for not found entities.
/// </summary>
public class NotFoundException : Exception
{
    /// <summary>
    ///     The field that was used to search for the entity.
    /// </summary>
    public string Field { get; }

    /// <summary>
    ///     The value of the field that was used to search for the entity.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// </summary>
    /// <param name="field"></param>
    /// <param name="value"></param>
    public NotFoundException(string field, string value)
        : base($"Entity with {field} '{value}' was not found.")
    {
        Field = field;
        Value = value;
    }
}
