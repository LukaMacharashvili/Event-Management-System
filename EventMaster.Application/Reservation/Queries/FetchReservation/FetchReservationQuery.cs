using ErrorOr;
using EventMaster.Domain.Reservations;
using MediatR;

namespace EventMaster.Application.Reservations.Queries.FetchReservation;

public record FetchReservationQuery(int ReservationId) : IRequest<ErrorOr<Reservation>>;
