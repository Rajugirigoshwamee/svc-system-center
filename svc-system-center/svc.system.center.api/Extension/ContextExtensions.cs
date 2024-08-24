using Microsoft.EntityFrameworkCore;
using svc.system.center.migration.DbContexts;

namespace Microsoft.Extensions.DependencyInjection;

public static class ContextExtensions
{
    public static IServiceCollection AddContext(this WebApplicationBuilder builder)
    {

        builder.Services.AddDbContext<MasterDbContext>(context => context.UseSqlServer(builder.Configuration.GetSection("ConnectionStrings:DefaultConnection").Value));

        return builder.Services;
    }
}
