using FluentValidation;

namespace EventMaster.Application.Reservations.Queries.LoadReservations;

public class LoadReservationsQueryValidator : AbstractValidator<LoadReservationsQuery>
{
    public LoadReservationsQueryValidator()
    {
        RuleFor(x => x.GuestId).NotEmpty();
    }
}