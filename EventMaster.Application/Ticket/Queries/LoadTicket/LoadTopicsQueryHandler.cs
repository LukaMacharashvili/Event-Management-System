using EventMaster.Application.Common.Interfaces.Persistence;
using ErrorOr;
using MediatR;
using EventMaster.Domain.Tickets;

namespace EventMaster.Application.Tickets.Queries.LoadTickets;

public class LoadTicketsQueryHandler : IRequestHandler<LoadTicketsQuery, ErrorOr<List<Ticket>>>
{
    private readonly ITicketRepository _ticketRepository;

    public LoadTicketsQueryHandler(ITicketRepository ticketRepository)
    {
        _ticketRepository = ticketRepository;
    }

    public async Task<ErrorOr<List<Ticket>>> Handle(LoadTicketsQuery request, CancellationToken cancellationToken)
    {
        return await _ticketRepository.LoadAsync(request.EventId);
    }
}