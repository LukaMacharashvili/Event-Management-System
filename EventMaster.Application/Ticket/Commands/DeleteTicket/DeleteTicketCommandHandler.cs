using EventMaster.Application.Common.Interfaces.Persistence;
using ErrorOr;
using MediatR;
using EventMaster.Domain.Tickets;
using EventMaster.Domain.Common.DomainErrors;

namespace EventMaster.Application.Tickets.Commands.DeleteTicket;

public class DeleteTicketCommandHandler : IRequestHandler<DeleteTicketCommand, ErrorOr<Ticket>>
{
    private readonly IEventRepository _eventRepository;
    private readonly ITicketRepository _ticketRepository;
    private readonly IUserRepository _hostRepository;

    public DeleteTicketCommandHandler(IEventRepository eventRepository,
    ITicketRepository ticketRepository, IUserRepository hostRepository)
    {
        _eventRepository = eventRepository;
        _ticketRepository = ticketRepository;
        _hostRepository = hostRepository;
    }

    public async Task<ErrorOr<Ticket>> Handle(DeleteTicketCommand request, CancellationToken cancellationToken)
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

        var ticket = @event?.Tickets?.FirstOrDefault(x => x.Id == request.TicketId);
        if (ticket is null)
        {
            return Errors.Ticket.TicketNotFound;
        }

        await _ticketRepository.DeleteAsync(ticket!);

        return ticket!;
    }
}