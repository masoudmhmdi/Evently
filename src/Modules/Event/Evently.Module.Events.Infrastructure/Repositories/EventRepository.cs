using Evently.Module.Events.Domain.Event;
using Evently.Module.Events.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

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

    public async Task<Event?> GetByIdAsync(Guid id)
    {
        Event? @event = await _dbContext.Events.SingleOrDefaultAsync(e => e.Id == id);
        return @event;
    }
}
