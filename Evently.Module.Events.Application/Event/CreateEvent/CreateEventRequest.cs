namespace Evently.Module.Events.Application.Event.CreateEvent;

public sealed record CreateEventRequest
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
    public DateTime StartAtUtc { get; set; }
    public DateTime EndAtUtc { get; set; }
}
