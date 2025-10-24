namespace Celeste.Identity.Data.Mapping;

using AutoMapper;

/// <summary>
///     Extensions for configuring data mappings.
/// </summary>
public static class DataMapping
{
    /// <summary>
    ///     Configure AutoMapper mappings.
    /// </summary>
    /// <param name="cfg"></param>
    /// <returns></returns>
    public static IMapperConfigurationExpression ConfigureDataMappings(this IMapperConfigurationExpression cfg)
    {
        cfg.AddProfile<PatientProfileDocumentProfile>();

        return cfg;
    }
}
