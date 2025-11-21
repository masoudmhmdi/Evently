using Evently.Module.Events.Domain.Event;
using Evently.Module.Events.Infrastructure.Database;

namespace Evently.Module.Events.Infrastructure.Repositories;

public class EventRepository : IEventRepository
{
    private readonly EventsDbContext _dbContext;

    public EventRepository(EventsDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public Event Insert(Event @event)
    {
        _dbContext.Events.Add(@event);
        return @event;
    }
}
