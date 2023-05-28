using FluentValidation;

namespace EventMaster.Application.EventReviews.Queries.LoadEventReviews;

public class LoadEventReviewsQueryValidator : AbstractValidator<LoadEventReviewsQuery>
{
    public LoadEventReviewsQueryValidator()
    {
        RuleFor(x => x.EventId).NotEmpty();
    }
}