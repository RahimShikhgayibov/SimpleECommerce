using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace SimpleECommerce.Application.Extensions;

public static class SwaggerExtensions
{
    public static void UseSwagger(this WebApplication app, 
        string solutionName,
        string projectName)
    {
        string loweredProjectName = projectName.ToLower();
        app.UseSwagger(c => c.RouteTemplate = loweredProjectName + "/swagger/{documentName}/swagger.json");
        app.UseSwaggerUI(c =>
        {
            c.RoutePrefix = $"swagger";
            c.SwaggerEndpoint($"/{loweredProjectName}/swagger/v1/swagger.json", $"{solutionName}.{projectName} v1");
            c.DocExpansion(DocExpansion.None);
        });
    }

    public static void AddSwaggerSecurityRequirement(this IServiceCollection services, 
        string solutionName,
        string projectName)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = $"{solutionName}.{projectName}", Version = "v1"
            });
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement()
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        },
                        Scheme = "oauth2",
                        Name = "Bearer",
                        In = ParameterLocation.Header,
                    },
                    new List<string>()
                }
            });
        });
    }
}