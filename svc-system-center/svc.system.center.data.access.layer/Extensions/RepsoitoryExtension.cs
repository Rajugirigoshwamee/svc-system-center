using svc.system.center.data.access.layer.Repository;
using svc.system.center.domain.Interfaces.Repositories;

namespace Microsoft.Extensions.DependencyInjection;

public static class RepsoitoryExtension
{
    public static IServiceCollection AddRepsoitoryExtension(this IServiceCollection services)
    {

        services.AddScoped<ICountryRepository, CountryRepository>();

        return services;
    }
}
