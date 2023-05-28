using FluentValidation;

namespace EventMaster.Application.Events.Queries.LoadEvents;

public class LoadEventsQueryValidator : AbstractValidator<LoadEventsQuery>
{
    public LoadEventsQueryValidator()
    {
    }
}