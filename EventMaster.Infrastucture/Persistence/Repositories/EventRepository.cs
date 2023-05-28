using EventMaster.Application.Common.Interfaces.Persistence;
using EventMaster.Domain.Events;
using Microsoft.EntityFrameworkCore;

namespace EventMaster.Infrastructure.Persistence.Repositories;

public class EventRepository : IEventRepository
{
    private readonly EventMasterDbContext _dbContext;

    public EventRepository(EventMasterDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Event>> LoadAsync()
    {
        return await _dbContext.Events
            .Include(e => e.Topics)
            .Include(e => e.Hosts)
            .ToListAsync();
    }

    public async Task<Event?> FetchAsync(int id)
    {
        return await _dbContext.Events
            .Include(e => e.Topics)
            .Include(e => e.Hosts)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Event?> AddAsync(Event @event)
    {
        var createdEvent = await _dbContext.Events.AddAsync(@event);
        await _dbContext.SaveChangesAsync();

        return createdEvent.Entity;
    }

    public async Task UpdateAsync(Event @event)
    {
        _dbContext.Events.Update(@event);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Event @event)
    {
        _dbContext.Events.Remove(@event);
        await _dbContext.SaveChangesAsync();
    }

}