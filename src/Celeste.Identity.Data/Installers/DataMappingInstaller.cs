namespace Celeste.Identity.Data.Installers;

using Celeste.Identity.Data.Mapping;
using Microsoft.Extensions.DependencyInjection;

/// <summary>
///     Installer for data mapping services.
/// </summary>
public static class DataMappingInstaller
{
    /// <summary>
    ///     Install the data mapping services dependencies.
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddDataMapping(this IServiceCollection services)
    {
        services.AddAutoMapper(cfg =>
        {
            cfg.AddProfile<PatientProfileProfile>();
        });

        return services;
    }
}
