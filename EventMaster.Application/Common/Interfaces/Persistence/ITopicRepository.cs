using EventMaster.Domain.Topics;

namespace EventMaster.Application.Common.Interfaces.Persistence;

public interface ITopicRepository
{
    Task<List<Topic>> LoadAsync(int eventId);
    Task<Topic?> FetchAsync(int id);
    Task<Topic?> AddAsync(Topic topic);
    Task UpdateAsync(Topic topic);
    Task DeleteAsync(Topic topic);
}