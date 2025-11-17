
namespace Evently.Module.Events.API.Events;

public static class GetEvent
{

    public static void MapEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("events/{id}", async (Guid id, EventsDbContext eventsDbContext) =>
        {
            Event? @event = await eventsDbContext.Events
                .Where(e => e.Id == id)
                .Select(e => new Event(
                    id,
                    e.Title,
                    e.Description,
                    e.Location,
                    e.StartAtUtc,
                    e.EndAtUtc,
                    e.Status))
                .SingleOrDefaultAsync();
            
            return @event is not null ? Results.Ok(@event) : Results.NotFound();
        });
    }
    
    internal sealed record Event(
        Guid Id, 
        string Title, 
        string Description, 
        string Location, 
        DateTime StartAtUtc, 
        DateTime EndAtUtc, 
        EventStatus Status
    );
}
