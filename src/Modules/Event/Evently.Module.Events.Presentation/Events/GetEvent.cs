using Evently.Module.Events.Application.Event.GetEvent;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Evently.Module.Events.Presentation.Events;

internal static class GetEvent
{

    public static void MapEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("events/{id}", async (Guid id, ISender sender) =>
        {
            var request = new GetEventRequest()
            {
                Id = id
            };
            
            GetEventResponse result = await sender.Send(request);
            return Results.Ok(result);
        });
    }
}
