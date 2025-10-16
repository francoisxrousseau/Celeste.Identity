namespace Celeste.Identity.Application.Installers;

using Microsoft.Extensions.DependencyInjection;

/// <summary>
///     Provides extension methods for registering MediatR request handlers in the application's dependency injection container.
/// </summary>
public static class RequestsHandlerInstaller
{
    /// <summary>
    ///     Registers all request handlers from the current assembly into the service collection.
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection RegisterRequestHandlers(
        this IServiceCollection services)
    {
        return services
            .AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(RequestsHandlerInstaller).Assembly));
    }
}
