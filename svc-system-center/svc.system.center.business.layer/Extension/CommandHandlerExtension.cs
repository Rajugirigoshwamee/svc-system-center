namespace Microsoft.Extensions.DependencyInjection;

public static class CommandHandlerExtension
{
    public static IServiceCollection AddCommandHandlerExtension(this IServiceCollection services)
    {

        services.AddScoped<ICommandHandler<AddCountryCommand, bool>, CountryCommandHandler>();
        services.Decorate<ICommandHandler<AddCountryCommand, bool>, TransactionCommandHandler<AddCountryCommand, bool>>();

        return services;
    }
}
