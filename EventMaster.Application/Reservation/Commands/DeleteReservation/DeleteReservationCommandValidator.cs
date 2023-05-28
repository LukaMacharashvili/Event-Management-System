using FluentValidation;

namespace EventMaster.Application.Reservations.Commands.DeleteReservation;

public class DeleteReservationCommandValidator : AbstractValidator<DeleteReservationCommand>
{
    public DeleteReservationCommandValidator()
    {
        RuleFor(x => x.ReservationId).NotEmpty();
        RuleFor(x => x.EventId).NotEmpty();
        RuleFor(x => x.GuestId).NotEmpty();
    }
}