using EventMaster.Application.Common.Interfaces.Persistence;
using ErrorOr;
using MediatR;
using EventMaster.Domain.Reservations;
using EventMaster.Domain.Common.DomainErrors;

namespace EventMaster.Application.Reservations.Commands.DeleteReservation;

public class DeleteReservationCommandHandler : IRequestHandler<DeleteReservationCommand, ErrorOr<Reservation>>
{
    private readonly IEventRepository _eventRepository;
    private readonly IReservationRepository _reservationRepository;
    private readonly IUserRepository _guestRepository;

    public DeleteReservationCommandHandler(IEventRepository eventRepository,
    IReservationRepository reservationRepository, IUserRepository guestRepository)
    {
        _reservationRepository = reservationRepository;
        _guestRepository = guestRepository;
        _eventRepository = eventRepository;
    }

    public async Task<ErrorOr<Reservation>> Handle(DeleteReservationCommand request, CancellationToken cancellationToken)
    {
        var @event = await _eventRepository.FetchAsync(request.EventId);
        if (@event is null)
        {
            return Errors.Event.EventNotFound;
        }

        var guest = await _guestRepository.FetchAsync(request.GuestId);
        if (guest is null)
        {
            return Errors.Guest.GuestNotFound;
        }
        if (@event?.Guests?.FirstOrDefault(x => x.GuestId == request.GuestId) is null)
        {
            return Errors.Guest.GuestNotAllowed;
        }

        var reservation = guest!.Reservations?.FirstOrDefault(x => x.Id == request.ReservationId);
        if (reservation is null)
        {
            return Errors.Reservation.ReservationNotFound;
        }

        @event.RemoveGuest(guest!);

        await _reservationRepository.DeleteAsync(reservation!);
        await _eventRepository.UpdateAsync(@event!);

        return reservation!;
    }
}