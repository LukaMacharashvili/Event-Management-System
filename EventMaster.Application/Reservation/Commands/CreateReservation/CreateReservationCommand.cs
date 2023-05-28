using ErrorOr;
using EventMaster.Domain.Reservations;
using MediatR;

namespace EventMaster.Application.Reservations.Commands.CreateReservation;

public record CreateReservationCommand(
    int EventId,
    int GuestId,
    int TicketId) : IRequest<ErrorOr<Reservation>>;
