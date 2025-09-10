using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace SimpleECommerce.Application.Extensions;

public static class CorsExtensions
{
    public static void UseCors(this WebApplication app)
    {
        IConfigurationSection cors = app.Configuration.GetSection("Cors:Origins");
        string[] origins = Array.Empty<string>();

        if (cors.Value != null)
        {
            origins = cors.Value.Split(";");
        }

        app.UseCors(builder =>
        {
            builder
                .WithOrigins(origins)
                .AllowCredentials()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
    }
}