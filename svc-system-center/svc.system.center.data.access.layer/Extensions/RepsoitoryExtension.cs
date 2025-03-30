using svc.birdcage.hawk.Implementation.Encryption;
using svc.birdcage.hawk.Interfaces.Encryption;
using svc.system.center.data.access.layer.Repository;
using svc.system.center.domain.Interfaces.Repositories;

namespace Microsoft.Extensions.DependencyInjection;

public static class RepsoitoryExtension
{
    public static IServiceCollection AddRepsoitoryExtension(this IServiceCollection services)
    {

        services.AddScoped<IEncryption, Encryption>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ICountryRepository, CountryRepository>();
        services.AddScoped<IStateRepository, StateRepository>();

        return services;
    }
}
