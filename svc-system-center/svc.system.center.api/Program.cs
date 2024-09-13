#region Set Environment

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.OpenApi.Models;

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

builder.Services.AddControllers();
builder.Services.AddApiVersioning(x =>
{
    x.DefaultApiVersion = new ApiVersion(1, 0);
    x.AssumeDefaultVersionWhenUnspecified = false;
    x.ReportApiVersions = false;
    x.ErrorResponses = new DefaultErrorResponseProvider();
});
builder.Services.AddEndpointsApiExplorer();

#endregion

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
