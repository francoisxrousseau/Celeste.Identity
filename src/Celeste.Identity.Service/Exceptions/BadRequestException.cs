namespace Celeste.Identity.Application.Exceptions;

using System;

/// <summary>
///     Custom exception for bad request exceptions.
/// </summary>
public class BadRequestException : Exception
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
    /// <param name="message"></param>
    public BadRequestException(string message)
        : base(message)
    {
    }

    /// <summary>
    /// </summary>
    /// <param name="message"></param>
    /// <param name="field"></param>
    /// <param name="value"></param>
    public BadRequestException(string message, string field, string value)
        : this($"The field : '{field}' with '{value}' is invalid. { message}")
    {
        Field = field;
        Value = value;
    }
}
