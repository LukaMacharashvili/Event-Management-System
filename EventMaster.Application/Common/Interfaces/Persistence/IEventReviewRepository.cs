using EventMaster.Domain.EventReviews;

namespace EventMaster.Application.Common.Interfaces.Persistence;

public interface IEventReviewRepository
{
    Task<List<EventReview>> LoadAsync(int eventId);
    Task<EventReview?> FetchAsync(int id);
    Task<EventReview?> AddAsync(EventReview eventReview);
    Task UpdateAsync(EventReview eventReview);
    Task DeleteAsync(EventReview eventReview);
}