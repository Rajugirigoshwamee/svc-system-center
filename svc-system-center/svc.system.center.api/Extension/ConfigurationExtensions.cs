using svc.system.center.Config;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigurationExtensions
{
    public static IServiceCollection AddConfigurations(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<ConnectionConfig>(builder.Configuration.GetSection("ConnectionStrings"));

        return builder.Services;
    }
}
