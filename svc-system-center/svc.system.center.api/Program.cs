#region Set Environment

using Microsoft.OpenApi.Models;
using svc.system.center.api.Helpers;

var EnveriometnName = string.Empty;

#if DEBUG

EnveriometnName = "Development";

#elif STAGGING

EnveriometnName = "Stagging";

#elif RELEASE    

EnveriometnName = "Production";

#endif

IConfiguration configuration = new ConfigurationBuilder().AddJsonFile($"appsettings.{EnveriometnName}.json").Build();

#endregion

#region Builder & Configuration

var builder = WebApplication.CreateBuilder(args);

#endregion

#region Service Configuration

#region Swagger Configuration

builder.Services.AddSwaggerGen(swagger =>
{
    swagger.SwaggerDoc("v1", new OpenApiInfo { Title = "Micro API - API Documentation", Version = "v1" });
});

#endregion

#region Initialization of Config

builder.AddConfigurations();

#endregion

#region Registering Dependency Injections

builder.Services.AddRepsoitoryExtension();
builder.Services.AddCommandHandlerExtension();
builder.Services.AddAssemblerExtension();

#endregion

#region Entity Framework Configure

builder.AddContext();

#endregion

builder.Services.AddControllers().SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Latest);
builder.Services.AddApiVersioning(x =>
{
    x.DefaultApiVersion = new Asp.Versioning.ApiVersion(1, 0);
    x.AssumeDefaultVersionWhenUnspecified = true;
    x.ReportApiVersions = true;
}).AddApiExplorer(x =>
{
    x.GroupNameFormat = "'v'VVV";
    x.SubstituteApiVersionInUrl = true;
});



#endregion

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

#region Seed Helper

using (var serviceScope = app.Services.CreateScope())
{
    var services = serviceScope.ServiceProvider;
    var myDependency = services.GetRequiredService<SeedHelper>();
    myDependency.Seed().Wait();
}

#endregion

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
