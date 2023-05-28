using EventMaster.Application.Common.Interfaces.Persistence;
using EventMaster.Domain.EventReviews;
using Microsoft.EntityFrameworkCore;

namespace EventMaster.Infrastructure.Persistence.Repositories;

public class EventReviewRepository : IEventReviewRepository
{
    private readonly EventMasterDbContext _dbContext;

    public EventReviewRepository(EventMasterDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<EventReview>> LoadAsync(int eventId)
    {
        return await _dbContext.EventReviews
            .Include(t => t.Guest)
            .Where(t => t.EventId == eventId)
            .ToListAsync();
    }

    public async Task<EventReview?> FetchAsync(int id)
    {
        return await _dbContext.EventReviews
            .Include(t => t.Guest)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<EventReview?> AddAsync(EventReview eventReview)
    {
        var createdEvent = await _dbContext.EventReviews.AddAsync(eventReview);
        await _dbContext.SaveChangesAsync();

        return createdEvent.Entity;
    }

    public async Task UpdateAsync(EventReview eventReview)
    {
        _dbContext.EventReviews.Update(eventReview);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(EventReview eventReview)
    {
        _dbContext.EventReviews.Remove(eventReview);
        await _dbContext.SaveChangesAsync();
    }

}