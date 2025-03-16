namespace Microsoft.Extensions.DependencyInjection;

public static class ValidatorExtensions
{
    public static IServiceCollection AddValidator(this WebApplicationBuilder builder)
    {

        return builder.Services;
    }
}
