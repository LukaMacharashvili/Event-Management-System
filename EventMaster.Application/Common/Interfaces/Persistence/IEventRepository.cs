using EventMaster.Domain.Events;

namespace EventMaster.Application.Common.Interfaces.Persistence;

public interface IEventRepository
{
    Task<List<Event>> LoadAsync();
    Task<Event?> FetchAsync(int id);
    Task<Event?> AddAsync(Event @event);
    Task UpdateAsync(Event @event);
    Task DeleteAsync(Event @event);
}