using EventMaster.Application.Common.Interfaces.Persistence;
using ErrorOr;
using MediatR;
using EventMaster.Domain.Common.DomainErrors;
using EventMaster.Domain.Reservations;

namespace EventMaster.Application.Reservations.Queries.FetchReservation;

public class FetchReservationQueryHandler : IRequestHandler<FetchReservationQuery, ErrorOr<Reservation>>
{
    private readonly IReservationRepository _reservationRepository;

    public FetchReservationQueryHandler(IReservationRepository reservationRepository)
    {
        _reservationRepository = reservationRepository;
    }

    public async Task<ErrorOr<Reservation>> Handle(FetchReservationQuery request, CancellationToken cancellationToken)
    {
        var reservation = await _reservationRepository.FetchAsync(request.ReservationId);

        if (reservation is null)
        {
            return Errors.Reservation.ReservationNotFound;
        }

        return reservation;
    }
}