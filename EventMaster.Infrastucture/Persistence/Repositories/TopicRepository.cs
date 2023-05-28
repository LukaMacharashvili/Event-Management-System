using EventMaster.Application.Common.Interfaces.Persistence;
using EventMaster.Domain.Topics;
using Microsoft.EntityFrameworkCore;

namespace EventMaster.Infrastructure.Persistence.Repositories;

public class TopicRepository : ITopicRepository
{
    private readonly EventMasterDbContext _dbContext;

    public TopicRepository(EventMasterDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Topic>> LoadAsync(int eventId)
    {
        return await _dbContext.Topics
            .Where(t => t.EventId == eventId)
            .ToListAsync();
    }

    public async Task<Topic?> FetchAsync(int id)
    {
        return await _dbContext.Topics.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Topic?> AddAsync(Topic topic)
    {
        var createdTopic = await _dbContext.Topics.AddAsync(topic);
        await _dbContext.SaveChangesAsync();

        return createdTopic.Entity;
    }

    public async Task UpdateAsync(Topic topic)
    {
        _dbContext.Topics.Update(topic);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Topic topic)
    {
        _dbContext.Topics.Remove(topic);
        await _dbContext.SaveChangesAsync();
    }

}