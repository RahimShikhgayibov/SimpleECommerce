using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.RateLimiting;
using SimpleECommerce.Application;
using SimpleECommerce.Infrastructure.Extensions;
using Microsoft.AspNetCore.RateLimiting;
using Serilog;
using OfficeOpenXml; // Add this import for EPPlus

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Set EPPlus license context here, before any services are configured
ExcelPackage.LicenseContext = LicenseContext.NonCommercial; // Change to Commercial if you have a license

builder.Services
    .AddControllers(options =>
    {
        options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
    }).AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.WriteIndented = true;
        options.JsonSerializerOptions.MaxDepth = 128;
    });

builder.Services.AddEndpointsApiExplorer();

if (!builder.Environment.IsProduction())
{
    builder.Services.AddSwaggerSecurityRequirement("KII", "WebAPI");
}

builder.Services.RegisterCustomDatabase(builder.Configuration);
builder.Services.RegisterCustomServices(builder.Configuration);

builder.Services.AddRateLimiter(l => l
    .AddSlidingWindowLimiter(policyName: "sliding", options =>
    {
        options.PermitLimit = 5;
        options.Window = TimeSpan.FromSeconds(30);
        options.SegmentsPerWindow = 5;
        options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
        options.QueueLimit = 2;
    }));

builder.Host.UseSerilog();

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .WriteTo.Debug()
    .WriteTo.Console()
    .CreateLogger();

try
{
    Log.Information("KII.WebAPI started");
    
    WebApplication app = builder.Build();
    
    await app.HandleExceptionAsync();
    
    app.UseCors();
    
    if (!app.Environment.IsProduction())
    {
        app.UseSwagger("SimpleECommerce", "WebAPI");
        await app.Services.InitialiseDatabaseAsync();
    }
    
    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();
    //app.MapHub<NotificationHub>("/hub/notifications");
    //app.MapHub<TicketHub>("/hub/tickets");
    app.MapControllers();
    app.UseRateLimiter();
    app.MapHealthChecks("/healthz");
    app.Run();
}
catch (Exception e)
{
    if (!e.GetType().Name.Equals("StopTheHostException", StringComparison.Ordinal))
    {
        Log.Fatal(e, "KII.WebAPI failed to start because of exception.");
        throw;
    }
}
finally
{
    Log.CloseAndFlush();
}