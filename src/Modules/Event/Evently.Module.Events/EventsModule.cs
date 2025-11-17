using Evently.Module.Events.API.Events;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Evently.Module.Events.API;

public static  class EventsModule
{
    public static void MapEndpoints(this IEndpointRouteBuilder endpoints)
    {
        CreateEvent.MapEndpoint(endpoints);
        GetEvent.MapEndpoints(endpoints);
    }
    
}
