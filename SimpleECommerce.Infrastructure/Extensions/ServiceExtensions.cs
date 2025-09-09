using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleECommerce.Infrastructure.Contexts;

namespace SimpleECommerce.Infrastructure.Extensions;

public static class ServiceExtensions
{
    public static void RegisterCustomDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DataContext>((_, options) =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                x => x.MigrationsHistoryTable("__migrations", "public")));
    }
}