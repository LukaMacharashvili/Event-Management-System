using ErrorOr;
using EventMaster.Domain.Tickets;
using MediatR;

namespace EventMaster.Application.Tickets.Queries.FetchTicket;

public record FetchTicketQuery(int TicketId) : IRequest<ErrorOr<Ticket>>;
