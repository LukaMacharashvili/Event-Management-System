using EventMaster.Application.Common.Interfaces.Persistence;
using ErrorOr;
using MediatR;
using EventMaster.Domain.Common.DomainErrors;
using EventMaster.Domain.Reservations;

namespace EventMaster.Application.Reservations.Commands.CreateReservation;

public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand, ErrorOr<Reservation>>
{
    private readonly IEventRepository _eventRepository;
    private readonly IReservationRepository _reservationRepository;
    private readonly IUserRepository _guestRepository;

    public CreateReservationCommandHandler(IEventRepository eventRepository,
    IReservationRepository reservationRepository, IUserRepository guestRepository)
    {
        _eventRepository = eventRepository;
        _reservationRepository = reservationRepository;
        _guestRepository = guestRepository;
    }

    public async Task<ErrorOr<Reservation>> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
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

        var ticket = @event.Tickets.FirstOrDefault(x => x.Id == request.TicketId);
        if (ticket is null)
        {
            return Errors.Ticket.TicketNotFound;
        }

        @event.AddGuest(guest);

        var accepted = @event!.EveryoneAllowed;
        var reservation = Reservation.Create(
            accepted,
            ticket,
            guest
        );

        await _reservationRepository.AddAsync(reservation);
        await _eventRepository.UpdateAsync(@event);

        return reservation;
    }
}