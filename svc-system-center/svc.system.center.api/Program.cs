#region Set Environment

using Asp.Versioning;
using Microsoft.OpenApi.Models;
using svc.system.center.api.Helpers;

var EnveriomentName = string.Empty;

#if DEBUG

EnveriomentName = "Development";

#elif STAGGING

EnveriomentName = "Stagging";

#elif RELEASE    

EnveriomentName = "Production";

#endif

IConfiguration configuration = new ConfigurationBuilder().AddJsonFile($"appsettings.{EnveriomentName}.json").Build();

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

#region Core Policy.

builder.Services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
{

#if DEBUG

    builder
    .WithOrigins("http://localhost:4200", "http://localhost", "http://localhost:19952", "http://localhost:8082")
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials()
     .WithExposedHeaders("X-Count");

#elif STAGGING

builder.WithOrigins("http://ibet333.com", "http://www.ibet333.com", "http://admin.ibet333.com:8082").AllowAnyMethod().AllowAnyHeader().AllowCredentials();

#elif RELEASE 

builder.WithOrigins("http://ibet333.com", "http://www.ibet333.com", "http://admin.ibet333.com:8082").AllowAnyMethod().AllowAnyHeader().AllowCredentials();

#endif


}));

#endregion

builder.Services.AddApiVersioning(x =>
{
    x.DefaultApiVersion = ApiVersion.Default;
    x.AssumeDefaultVersionWhenUnspecified = true;
    x.ReportApiVersions = true;
}).AddApiExplorer(x =>
{
    x.GroupNameFormat = "'v'VVV";
    x.SubstituteApiVersionInUrl = true;
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();


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

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
