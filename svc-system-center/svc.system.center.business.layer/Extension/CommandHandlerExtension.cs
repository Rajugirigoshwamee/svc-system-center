using svc.birdcage.hawk.Commands;
using svc.system.center.business.layer.Handler;
using svc.system.center.domain.Commands.City;
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

        services.AddScoped<ICommandHandler<AddStateCommand, bool>, StateCommandHandler>();
        services.AddScoped<ICommandHandler<DeleteStateCommand, bool>, StateCommandHandler>();
        services.AddScoped<ICommandHandler<UpdateStateCommand, bool>, StateCommandHandler>();
        services.Decorate<ICommandHandler<AddStateCommand, bool>, TransactionCommandHandler<AddStateCommand, bool>>();
        services.Decorate<ICommandHandler<DeleteStateCommand, bool>, TransactionCommandHandler<DeleteStateCommand, bool>>();
        services.Decorate<ICommandHandler<UpdateStateCommand, bool>, TransactionCommandHandler<UpdateStateCommand, bool>>();

        services.AddScoped<ICommandHandler<AddCityCommand, bool>, CityCommandHandler>();
        services.AddScoped<ICommandHandler<DeleteCityCommand, bool>, CityCommandHandler>();
        services.AddScoped<ICommandHandler<UpdateCityCommand, bool>, CityCommandHandler>();
        services.Decorate<ICommandHandler<AddCityCommand, bool>, TransactionCommandHandler<AddCityCommand, bool>>();
        services.Decorate<ICommandHandler<DeleteCityCommand, bool>, TransactionCommandHandler<DeleteCityCommand, bool>>();
        services.Decorate<ICommandHandler<UpdateCityCommand, bool>, TransactionCommandHandler<UpdateCityCommand, bool>>();

        return services;
    }
}
