﻿namespace Microsoft.Extensions.DependencyInjection;

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
