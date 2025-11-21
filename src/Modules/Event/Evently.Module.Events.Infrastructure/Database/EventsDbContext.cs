using Evently.Module.Events.Application.Abstractions;
using Evently.Module.Events.Domain.Event;
using Microsoft.EntityFrameworkCore;

namespace Evently.Module.Events.Infrastructure.Database;

public class EventsDbContext : DbContext , IUnitOfWork
{
    public EventsDbContext(DbContextOptions<EventsDbContext> options)
        : base(options)
    {
    }
    
    internal DbSet<Event> Events { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("events");
    }

}

