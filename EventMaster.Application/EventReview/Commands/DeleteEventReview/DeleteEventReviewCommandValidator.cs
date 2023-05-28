using FluentValidation;

namespace EventMaster.Application.EventReviews.Commands.DeleteEventReview;

public class DeleteEventReviewCommandValidator : AbstractValidator<DeleteEventReviewCommand>
{
    public DeleteEventReviewCommandValidator()
    {
        RuleFor(x => x.GuestId).NotEmpty();
        RuleFor(x => x.EventReviewId).NotEmpty();
    }
}