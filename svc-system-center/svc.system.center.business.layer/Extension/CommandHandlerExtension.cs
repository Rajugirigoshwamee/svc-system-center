using svc.birdcage.hawk.Commands;
using svc.system.center.business.layer.Handler;
using svc.system.center.business.layer.Handler.Country;
using svc.system.center.domain.Commands.Country;

namespace Microsoft.Extensions.DependencyInjection;

public static class CommandHandlerExtension
{
    public static IServiceCollection AddCommandHandlerExtension(this IServiceCollection services)
    {

        services.AddScoped<ICommandHandler<AddCountryCommand, bool>, CountryCommandHandler>();
        services.AddScoped<ICommandHandler<DeleteCountryCommand, bool>, CountryCommandHandler>();
        services.AddScoped<ICommandHandler<UpdateCountryCommand, bool>, CountryCommandHandler>();
        services.Decorate<ICommandHandler<AddCountryCommand, bool>, TransactionCommandHandler<AddCountryCommand, bool>>();
        services.Decorate<ICommandHandler<DeleteCountryCommand, bool>, TransactionCommandHandler<DeleteCountryCommand, bool>>();
        services.Decorate<ICommandHandler<UpdateCountryCommand, bool>, TransactionCommandHandler<UpdateCountryCommand, bool>>();

        return services;
    }
}
