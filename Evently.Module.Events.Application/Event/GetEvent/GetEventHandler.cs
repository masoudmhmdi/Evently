using Evently.Module.Events.Domain.Event;
using MediatR;

namespace Evently.Module.Events.Application.Event.GetEvent;

public class GetEventHandler : IRequestHandler<GetEventRequest, GetEventResponse>
{
    private readonly IEventRepository _eventRepository;

    public GetEventHandler(
       IEventRepository eventRepository
        )
    {
        _eventRepository = eventRepository;
    }
    public async Task<GetEventResponse> Handle(GetEventRequest request, CancellationToken cancellationToken)
    {
        Domain.Event.Event? @event = await _eventRepository.GetByIdAsync(request.Id);

        if (@event is null)
        {
            return new GetEventResponse();
        }
        var x = new GetEventResponse()
        {
            Description = @event.Description,
            EndAtUtc = @event.EndAtUtc,
            StartAtUtc = @event.StartAtUtc,
            Location = @event.Location,
            Title = @event.Title,
        };
        
        return x;

    }
}
