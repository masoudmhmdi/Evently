using Evently.Module.Events.Application.Event.CreateEvent;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Evently.Module.Events.Presentation.Events;

internal static class CreateEvent
{
    public static void MapEndpoint(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("events", async (Request request, ISender sender) =>
        {
            var query = new CreateEventQuery()
            {
                Description = request.Description,
                EndAtUtc = request.EndAtUtc,
                StartAtUtc = request.StartAtUtc,
                Location = request.Location,
                Title = request.Title,
            };
            
            Guid result = await sender.Send(query);
            
            return Results.Ok(result);
        }).WithTags("events");
    }


    public sealed class Request
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime StartAtUtc { get; set; }
        public DateTime EndAtUtc { get; set; }
    }

}
