using EventMaster.Application.Common.Interfaces.Persistence;
using ErrorOr;
using MediatR;
using EventMaster.Domain.EventReviews;

namespace EventMaster.Application.EventReviews.Queries.LoadEventReviews;

public class LoadEventReviewsQueryHandler : IRequestHandler<LoadEventReviewsQuery, ErrorOr<List<EventReview>>>
{
    private readonly IEventReviewRepository _eventReviewRepository;

    public LoadEventReviewsQueryHandler(IEventReviewRepository eventReviewRepository)
    {
        _eventReviewRepository = eventReviewRepository;
    }

    public async Task<ErrorOr<List<EventReview>>> Handle(LoadEventReviewsQuery request, CancellationToken cancellationToken)
    {
        return await _eventReviewRepository.LoadAsync(request.EventId);
    }
}