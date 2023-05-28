using EventMaster.Application.Common.Interfaces.Persistence;
using ErrorOr;
using MediatR;
using EventMaster.Domain.Reservations;

namespace EventMaster.Application.Reservations.Queries.LoadReservations;

public class LoadReservationsQueryHandler : IRequestHandler<LoadReservationsQuery, ErrorOr<List<Reservation>>>
{
    private readonly IReservationRepository _reservationRepository;

    public LoadReservationsQueryHandler(IReservationRepository reservationRepository)
    {
        _reservationRepository = reservationRepository;
    }

    public async Task<ErrorOr<List<Reservation>>> Handle(LoadReservationsQuery request, CancellationToken cancellationToken)
    {
        return await _reservationRepository.LoadAsync(request.GuestId);
    }
}