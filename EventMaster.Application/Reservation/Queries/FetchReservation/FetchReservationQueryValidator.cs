using FluentValidation;

namespace EventMaster.Application.Reservations.Queries.FetchReservation;

public class FetchReservationQueryValidator : AbstractValidator<FetchReservationQuery>
{
    public FetchReservationQueryValidator()
    {
        RuleFor(x => x.ReservationId).NotEmpty();
    }
}