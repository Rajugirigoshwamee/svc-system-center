using svc.system.center.data.access.layer.Assembler.Public;
using svc.system.center.data.access.layer.Repository;
using svc.system.center.domain.Interfaces.Assemblers.Public;

namespace Microsoft.Extensions.DependencyInjection;

public static class AssemblerExtension
{
    public static IServiceCollection AddAssemblerExtension(this IServiceCollection services)
    {

        services.AddScoped<ICountryAssembler, CountryAssembler>();

        return services;
    }
}
