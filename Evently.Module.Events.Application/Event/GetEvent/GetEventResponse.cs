using Evently.Module.Events.Domain.Event;

namespace Evently.Module.Events.Application.Event.GetEvent;

public class GetEventResponse
{
    
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
    public DateTime StartAtUtc { get; set; }
    public DateTime EndAtUtc { get; set; }
    public EventStatus Status { get; set; }

}
