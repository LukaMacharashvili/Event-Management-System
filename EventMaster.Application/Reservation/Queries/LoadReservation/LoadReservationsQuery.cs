using ErrorOr;
using EventMaster.Domain.Reservations;
using MediatR;

namespace EventMaster.Application.Reservations.Queries.LoadReservations;

public record LoadReservationsQuery(int GuestId) : IRequest<ErrorOr<List<Reservation>>>;
