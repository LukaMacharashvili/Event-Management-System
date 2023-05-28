using ErrorOr;
using EventMaster.Domain.EventReviews;
using MediatR;

namespace EventMaster.Application.EventReviews.Queries.FetchEventReview;

public record FetchEventReviewQuery(int EventReviewId) : IRequest<ErrorOr<EventReview>>
{
    public FetchEventReviewQuery() : this(0) { }
}
