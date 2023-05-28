using ErrorOr;
using EventMaster.Domain.EventReviews;
using MediatR;

namespace EventMaster.Application.EventReviews.Commands.DeleteEventReview;

public record DeleteEventReviewCommand(
    int EventReviewId,
    int GuestId) : IRequest<ErrorOr<EventReview>>
{
    public DeleteEventReviewCommand() : this(0, 0) { }
}
