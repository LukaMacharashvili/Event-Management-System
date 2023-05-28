using EventMaster.Application.Common.Interfaces.Persistence;
using ErrorOr;
using MediatR;
using EventMaster.Domain.Common.DomainErrors;
using EventMaster.Domain.Tickets;

namespace EventMaster.Application.Tickets.Commands.CreateTicket;

public class CreateTicketCommandHandler : IRequestHandler<CreateTicketCommand, ErrorOr<Ticket>>
{
    private readonly IEventRepository _eventRepository;
    private readonly ITicketRepository _ticketRepository;
    private readonly IUserRepository _hostRepository;

    public CreateTicketCommandHandler(IEventRepository eventRepository,
    ITicketRepository ticketRepository, IUserRepository hostRepository)
    {
        _eventRepository = eventRepository;
        _ticketRepository = ticketRepository;
        _hostRepository = hostRepository;
    }

    public async Task<ErrorOr<Ticket>> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
    {
        var @event = await _eventRepository.FetchAsync(request.EventId);
        if (@event is null)
        {
            return Errors.Event.EventNotFound;
        }

        var host = await _hostRepository.FetchAsync(request.HostId);
        if (host is null)
        {
            return Errors.Host.HostNotFound;
        }

        if (@event?.Hosts?.FirstOrDefault(x => x.HostId == request.HostId) is null)
        {
            return Errors.Host.HostNotAllowed;
        }

        var ticket = Ticket.Create(
            @event,
            request.Type
        );

        await _ticketRepository.AddAsync(ticket);

        return ticket;
    }
}