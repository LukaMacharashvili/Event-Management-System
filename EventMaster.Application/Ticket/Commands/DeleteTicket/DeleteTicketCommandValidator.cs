using FluentValidation;

namespace EventMaster.Application.Tickets.Commands.DeleteTicket;

public class DeleteTicketCommandValidator : AbstractValidator<DeleteTicketCommand>
{
    public DeleteTicketCommandValidator()
    {
        RuleFor(x => x.TicketId).NotEmpty();
        RuleFor(x => x.EventId).NotEmpty();
        RuleFor(x => x.HostId).NotEmpty();
    }
}