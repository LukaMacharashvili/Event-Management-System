using FluentValidation;

namespace EventMaster.Application.Tickets.Queries.LoadTickets;

public class LoadTicketsQueryValidator : AbstractValidator<LoadTicketsQuery>
{
    public LoadTicketsQueryValidator()
    {
        RuleFor(x => x.EventId).NotEmpty();
    }
}