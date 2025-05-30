﻿using Microsoft.EntityFrameworkCore;
using svc.birdcage.hawk.Implementation.Dapper;
using svc.birdcage.hawk.Interfaces.Dapper;
using svc.system.center.api.Filters;
using svc.system.center.api.Helpers;
using svc.system.center.migration.DbContexts;

namespace Microsoft.Extensions.DependencyInjection;

public static class ContextExtensions
{
    public static IServiceCollection AddContext(this WebApplicationBuilder builder)
    {
        string connectionString = builder.Configuration.GetSection("ConnectionStrings:DefaultConnection").Value!;
        builder.Services.AddDbContext<MasterDbContext>(context => context.UseSqlServer(connectionString));
        builder.Services.AddTransient<IDapperService>(x => new DapperServices(connectionString!));
        builder.Services.AddScoped<SeedHelper>();
        builder.Services.AddScoped<ExceptionFilters>();

        return builder.Services;
    }
}
