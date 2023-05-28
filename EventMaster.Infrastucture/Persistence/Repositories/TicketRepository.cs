using EventMaster.Application.Common.Interfaces.Persistence;
using EventMaster.Domain.Tickets;
using Microsoft.EntityFrameworkCore;

namespace EventMaster.Infrastructure.Persistence.Repositories;

public class TicketRepository : ITicketRepository
{
    private readonly EventMasterDbContext _dbContext;

    public TicketRepository(EventMasterDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Ticket>> LoadAsync(int eventId)
    {
        return await _dbContext.Tickets
            .Where(t => t.EventId == eventId)
            .ToListAsync();
    }

    public async Task<Ticket?> FetchAsync(int id)
    {
        return await _dbContext.Tickets.FindAsync(id);
    }

    public async Task<Ticket?> AddAsync(Ticket ticket)
    {
        var createdTicket = await _dbContext.Tickets.AddAsync(ticket);
        await _dbContext.SaveChangesAsync();

        return createdTicket.Entity;
    }

    public async Task UpdateAsync(Ticket ticket)
    {
        _dbContext.Tickets.Update(ticket);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Ticket ticket)
    {
        _dbContext.Tickets.Remove(ticket);
        await _dbContext.SaveChangesAsync();
    }

}