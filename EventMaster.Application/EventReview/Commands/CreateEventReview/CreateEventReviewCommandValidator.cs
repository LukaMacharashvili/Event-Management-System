using FluentValidation;

namespace EventMaster.Application.EventReviews.Commands.CreateEventReview;

public class CreateEventReviewCommandValidator : AbstractValidator<CreateEventReviewCommand>
{
    public CreateEventReviewCommandValidator()
    {
        RuleFor(x => x.Title).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.Stars).NotEmpty();
    }
}