using Evently.Module.Events.Application.Abstractions;
using Evently.Module.Events.Domain.Event;
using MediatR;

namespace Evently.Module.Events.Application.Event.CreateEvent;

public class CreateEventQueryHandler : IRequestHandler<CreateEventQuery, Guid>
{
    private readonly IEventRepository _eventRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateEventQueryHandler(IEventRepository eventRepository, IUnitOfWork unitOfWork)
    {
        _eventRepository = eventRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateEventQuery request, CancellationToken cancellationToken)
    {
        var @event = Domain.Event.Event.Create(
            request.Title,
            request.Description,
            request.Location,
            request.StartAtUtc.ToUniversalTime(),
            request.EndAtUtc.ToUniversalTime()
        );

         _eventRepository.Insert(@event);
         
         await _unitOfWork.SaveChangesAsync(cancellationToken);

         return @event.Id;

    }
}
