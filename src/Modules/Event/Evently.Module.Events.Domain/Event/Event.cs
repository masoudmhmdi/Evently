namespace Evently.Module.Events.Domain.Event;

public sealed class Event
{
    private Event()
    {
        
    }
   public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public string Location { get; private set; }
    public DateTime StartAtUtc { get; private set; }
    public DateTime EndAtUtc { get; private set; }
    public EventStatus Status { get; private set; }


    public static Event Create(
        string title,
        string description,
        string location,
        DateTime startAtUtc,
        DateTime endAtUtc)
    {

        return new Event()
        {
            Title = title,
            Description = description,
            EndAtUtc = endAtUtc,
            StartAtUtc = startAtUtc,
            Location = location,
        };
    }
}

