using FluentValidation;

namespace EventMaster.Application.Tickets.Commands.CreateTicket;

public class CreateTicketCommandValidator : AbstractValidator<CreateTicketCommand>
{
    public CreateTicketCommandValidator()
    {
        RuleFor(x => x.Type).NotEmpty();
        RuleFor(x => x.EventId).NotEmpty();
        RuleFor(x => x.HostId).NotEmpty();
    }
}