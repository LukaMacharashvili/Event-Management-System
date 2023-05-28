using EventMaster.Application.Common.Interfaces.Persistence;
using ErrorOr;
using MediatR;
using EventMaster.Domain.Common.DomainErrors;
using EventMaster.Domain.EventReviews;

namespace EventMaster.Application.EventReviews.Queries.FetchEventReview;

public class FetchEventReviewQueryHandler : IRequestHandler<FetchEventReviewQuery, ErrorOr<EventReview>>
{
    private readonly IEventReviewRepository _eventReviewRepository;

    public FetchEventReviewQueryHandler(IEventReviewRepository eventReviewRepository)
    {
        _eventReviewRepository = eventReviewRepository;
    }

    public async Task<ErrorOr<EventReview>> Handle(FetchEventReviewQuery request, CancellationToken cancellationToken)
    {
        var eventReview = await _eventReviewRepository.FetchAsync(request.EventReviewId);

        if (eventReview is null)
        {
            return Errors.EventReview.EventReviewNotFound;
        }

        return eventReview;
    }
}