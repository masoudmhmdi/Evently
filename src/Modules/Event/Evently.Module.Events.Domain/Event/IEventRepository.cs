namespace Evently.Module.Events.Domain.Event;

public interface IEventRepository
{
    Event Insert(Event @event);

}
