using MediatR;

namespace Evently.Module.Events.Application.Event.GetEvent;

public class GetEventRequest : IRequest<GetEventResponse>
{
    public Guid Id { get; set; }
}
