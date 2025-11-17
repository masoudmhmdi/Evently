using Evently.Module.Events.Domain.Event;
using Microsoft.EntityFrameworkCore;

namespace Evently.Module.Events.Infrastructure.Database;

public class EventsDbContext(DbContextOptions<EventsDbContext> options) : DbContext(options)
{
    internal DbSet<Event> Events { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("events");
    }
    
}

