using ErrorOr;
using EventMaster.Domain.Tickets;
using MediatR;

namespace EventMaster.Application.Tickets.Commands.DeleteTicket;

public record DeleteTicketCommand(
    int TicketId,
    int EventId,
    int HostId) : IRequest<ErrorOr<Ticket>>;
