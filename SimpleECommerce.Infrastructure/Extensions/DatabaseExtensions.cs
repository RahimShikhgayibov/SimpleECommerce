using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SimpleECommerce.Infrastructure.Contexts;

namespace SimpleECommerce.Infrastructure.Extensions;

public static class DatabaseExtensions
{
    public static async Task InitialiseDatabaseAsync(this IServiceProvider services)
    {
        using var scope = services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<DataContext>();
        await context.Database.MigrateAsync();
    }
}