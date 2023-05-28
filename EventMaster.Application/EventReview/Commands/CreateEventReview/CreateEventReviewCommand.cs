using ErrorOr;
using EventMaster.Domain.EventReviews;
using MediatR;

namespace EventMaster.Application.EventReviews.Commands.CreateEventReview;

public record CreateEventReviewCommand(
    int GuestId,
    int EventId,
    string Title,
    string Description,
    int Stars) : IRequest<ErrorOr<EventReview>>
{
    public CreateEventReviewCommand() : this(0, 0, "", "", 0) { }
}
