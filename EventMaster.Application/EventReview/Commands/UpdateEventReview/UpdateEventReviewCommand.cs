using ErrorOr;
using MediatR;
using EventMaster.Domain.EventReviews;

namespace EventMaster.Application.EventReviews.Commands.UpdateEventReview;

public record UpdateEventReviewCommand(
    int GuestId,
    int EventReviewId,
    string? Title,
    string? Description,
    int? Stars) : IRequest<ErrorOr<EventReview>>
{
    public UpdateEventReviewCommand() : this(0, 0, "", "", 0) { }
}

