using ErrorOr;
using EventMaster.Domain.EventReviews;
using MediatR;

namespace EventMaster.Application.EventReviews.Queries.LoadEventReviews;

public record LoadEventReviewsQuery(int EventId) : IRequest<ErrorOr<List<EventReview>>>;
