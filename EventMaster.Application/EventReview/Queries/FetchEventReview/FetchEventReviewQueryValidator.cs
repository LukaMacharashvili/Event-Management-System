using FluentValidation;

namespace EventMaster.Application.EventReviews.Queries.FetchEventReview;

public class FetchEventReviewQueryValidator : AbstractValidator<FetchEventReviewQuery>
{
    public FetchEventReviewQueryValidator()
    {
        RuleFor(x => x.EventReviewId).NotEmpty();
    }
}