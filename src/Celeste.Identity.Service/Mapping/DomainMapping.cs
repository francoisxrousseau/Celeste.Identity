namespace Celeste.Identity.Application.Mapping;

using AutoMapper;

/// <summary>
///     Extensions for configuring domain mappings.
/// </summary>
public static class DomainMapping
{
    /// <summary>
    ///     Configure AutoMapper mappings.
    /// </summary>
    /// <param name="cfg"></param>
    /// <returns></returns>
    public static IMapperConfigurationExpression ConfigureDomainMappings(this IMapperConfigurationExpression cfg)
    {
        cfg.AddProfile<PatientProfileDomainProfile>();

        return cfg;
    }
}