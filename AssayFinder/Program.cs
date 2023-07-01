using AssayFinder.Extensions;
using Interfaces;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NLog;
using Microsoft.AspNetCore.Mvc.Formatters;
using AssayFinder.Presentation.ActionFilters;

var builder = WebApplication.CreateBuilder(args);

LogManager.Setup().LoadConfigurationFromFile("/nlog.config");

// Add services to the container.
builder.Services.ConfigCors();
builder.Services.ConfigureLoggerService();
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.AddAutoMapper(typeof(Program));

// To enable us to use custom responses
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

//Action filters
builder.Services.AddScoped<ValidationFilterAttribute>();

builder.Services.AddControllers(config =>
{
    config.RespectBrowserAcceptHeader = true;
    config.ReturnHttpNotAcceptable = true;
})
    // As controllers are in the presentation layer
    .AddApplicationPart(typeof(AssayFinder.Presentation.AssemblyReference).Assembly)
    // For JSON Patch
    .AddNewtonsoftJson();

builder.Services.Configure<MvcNewtonsoftJsonOptions>(opts => 
{
    opts.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
var logger = app.Services.GetRequiredService<ILoggerManager>();
app.ConfigureExceptionHandler(logger);

if (app.Environment.IsProduction())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
