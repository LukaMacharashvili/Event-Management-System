using EventMaster.Application.Common.Interfaces.Persistence;
using ErrorOr;
using MediatR;
using EventMaster.Domain.Common.DomainErrors;
using EventMaster.Domain.Tickets;

namespace EventMaster.Application.Tickets.Queries.FetchTicket;

public class FetchTicketQueryHandler : IRequestHandler<FetchTicketQuery, ErrorOr<Ticket>>
{
    private readonly ITicketRepository _ticketRepository;

    public FetchTicketQueryHandler(ITicketRepository ticketRepository)
    {
        _ticketRepository = ticketRepository;
    }

    public async Task<ErrorOr<Ticket>> Handle(FetchTicketQuery request, CancellationToken cancellationToken)
    {
        var ticket = await _ticketRepository.FetchAsync(request.TicketId);

        if (ticket is null)
        {
            return Errors.Event.EventNotFound;
        }

        return ticket;
    }
}