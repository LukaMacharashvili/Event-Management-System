using EventMaster.Domain.Tickets;

namespace EventMaster.Application.Common.Interfaces.Persistence;

public interface ITicketRepository
{
    Task<List<Ticket>> LoadAsync(int eventId);
    Task<Ticket?> FetchAsync(int id);
    Task<Ticket?> AddAsync(Ticket ticket);
    Task UpdateAsync(Ticket ticket);
    Task DeleteAsync(Ticket ticket);
}