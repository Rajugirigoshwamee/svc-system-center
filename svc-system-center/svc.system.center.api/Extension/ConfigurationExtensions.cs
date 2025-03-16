using svc.system.center.Config;
using svc.system.center.domain.Config;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigurationExtensions
{
    public static IServiceCollection AddConfigurations(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<ConnectionConfig>(builder.Configuration.GetSection("ConnectionStrings"));
        builder.Services.Configure<AuthConfig>(builder.Configuration.GetSection("Authentication"));

        return builder.Services;
    }
}
