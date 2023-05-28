using ErrorOr;
using EventMaster.Domain.Tickets;
using MediatR;

namespace EventMaster.Application.Tickets.Queries.LoadTickets;

public record LoadTicketsQuery(int EventId) : IRequest<ErrorOr<List<Ticket>>>;
