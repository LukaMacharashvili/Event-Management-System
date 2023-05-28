using ErrorOr;
using EventMaster.Domain.Reservations;
using MediatR;

namespace EventMaster.Application.Reservations.Commands.DeleteReservation;

public record DeleteReservationCommand(
    int ReservationId,
    int GuestId,
    int EventId) : IRequest<ErrorOr<Reservation>>;
