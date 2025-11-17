using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Evently.Module.Events.Presentation.Events;

internal static class GetEvent
{

    public static void MapEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("events/{id}", (Guid id) =>
        {
            return Results.Ok(Task.FromResult("ok"));
        });
    }
    
    internal sealed record Event(
        Guid Id, 
        string Title, 
        string Description, 
        string Location, 
        DateTime StartAtUtc, 
        DateTime EndAtUtc 
    );
}
