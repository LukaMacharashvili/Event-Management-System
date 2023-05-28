using FluentValidation;

namespace EventMaster.Application.Topics.Queries.LoadTopics;

public class LoadTopicsQueryValidator : AbstractValidator<LoadTopicsQuery>
{
    public LoadTopicsQueryValidator()
    {
        RuleFor(x => x.EventId).NotEmpty();
    }
}