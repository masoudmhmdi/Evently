using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Evently.Module.Events.API.Events;

public static class CreateEvent
{
    public static void MapEndpoint(IEndpointRouteBuilder endpoints)
    {

        endpoints.MapGet("events", (Request request, ISer) =>
        {


        }).WithTags("events");
    }


    private sealed class Request
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime StartAtUtc { get; set; }
        public DateTime EndAtUtc { get; set; }
    }

}
