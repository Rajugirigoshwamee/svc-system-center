using svc.system.center.data.access.layer.Repository;

namespace Microsoft.Extensions.DependencyInjection;

public static class RepsoitoryExtension
{
    public static IServiceCollection AddRepsoitoryExtension(this IServiceCollection services)
    {

        services.AddScoped<ICountryRepository, CountryRepository>();

        return services;
    }
}
