namespace Celeste.Identity.Core.Options;

/// <summary>
///     The database options.
/// </summary>
public class DatabaseOptions
{
    /// <summary>
    ///     The database host.
    /// </summary>
    public string Host { get; set; }

    /// <summary>
    ///     The database port.
    /// </summary>
    public string Port { get; set; }

    /// <summary>
    ///     The database name.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    ///     The database connection string.
    /// </summary>
    public string ConnectionString => $"mongodb://{Host}:{Port}";

}
