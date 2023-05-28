using FluentValidation;

namespace EventMaster.Application.Events.Queries.FetchEvent;

public class FetchEventQueryValidator : AbstractValidator<FetchEventQuery>
{
    public FetchEventQueryValidator()
    {
        RuleFor(x => x.EventId).NotEmpty();
    }
}