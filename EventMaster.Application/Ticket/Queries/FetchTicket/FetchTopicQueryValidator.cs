using FluentValidation;

namespace EventMaster.Application.Tickets.Queries.FetchTicket;

public class FetchTicketQueryValidator : AbstractValidator<FetchTicketQuery>
{
    public FetchTicketQueryValidator()
    {
        RuleFor(x => x.TicketId).NotEmpty();
    }
}