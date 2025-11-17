using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Evently.Module.Events.Infrastructure.Database.Extension;

public static class MigrationExtension
{

    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();
        ApplyMigrationContext<EventsDbContext>(scope);
    }

    private static void ApplyMigrationContext<TContext>(IServiceScope scope)
        where TContext : DbContext
    {
        TContext context = scope.ServiceProvider.GetRequiredService<TContext>();
        
        context.Database.Migrate();
        
    }
}
