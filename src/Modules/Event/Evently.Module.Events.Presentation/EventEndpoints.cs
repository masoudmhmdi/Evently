using Evently.Module.Events.Presentation.Events;
using Microsoft.AspNetCore.Routing;

namespace Evently.Module.Events.Presentation;

public static class EventEndpoints
{
    public static void MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        CreateEvent.MapEndpoint(endpoints);
        GetEvent.MapEndpoints(endpoints);
    }
    
}
