using Evently.Module.Events.Application.Abstractions;
using Evently.Module.Events.Application.Event.CreateEvent;
using Evently.Module.Events.Domain.Event;
using Evently.Module.Events.Infrastructure.Database;
using Evently.Module.Events.Infrastructure.Repositories;
using Evently.Module.Events.Presentation;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Evently.Module.Events.Infrastructure;

public static class Extension
{
    public static IServiceCollection AddEventsModule(
        this IServiceCollection services,
        IConfiguration configuration)
    {

        string databaseConnectionString = configuration.GetConnectionString("Database")!;

        services.AddDbContext<EventsDbContext>(option =>
        {
            option.UseNpgsql(databaseConnectionString, op =>
            {
                op.MigrationsHistoryTable(HistoryRepository.DefaultTableName, Schema.Events);
            });
            
            option.UseSnakeCaseNamingConvention();
        });


        services.AddMediatR(option =>
        {
            option.RegisterServicesFromAssembly(typeof(CreateEventQuery).Assembly);
        });

        services.AddScoped<IEventRepository, EventRepository>();

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<EventsDbContext>());

        return services;
        
    }


    public static void MapEventModuleEndpoints(this IEndpointRouteBuilder endpoints)
    {
        EventEndpoints.MapEndpoints(endpoints);
        
    }
}

