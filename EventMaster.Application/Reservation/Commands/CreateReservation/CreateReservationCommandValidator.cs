using FluentValidation;

namespace EventMaster.Application.Reservations.Commands.CreateReservation;

public class CreateReservationCommandValidator : AbstractValidator<CreateReservationCommand>
{
    public CreateReservationCommandValidator()
    {
        RuleFor(x => x.EventId).NotEmpty();
        RuleFor(x => x.TicketId).NotEmpty();
        RuleFor(x => x.GuestId).NotEmpty();
    }
}