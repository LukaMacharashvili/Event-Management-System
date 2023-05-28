using EventMaster.Application.EventReviews.Commands.UpdateEventReview;
using FluentValidation;

namespace EventMaster.Application.EventReviews.Commands.UpdateEvent;

public class UpdateEventCommandValidator : AbstractValidator<UpdateEventReviewCommand>
{
    public UpdateEventCommandValidator()
    {
        RuleFor(x => x.GuestId).NotEmpty();
        RuleFor(x => x.EventReviewId).NotEmpty();
        RuleFor(x => x.Title).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.Stars).NotEmpty();
    }
}