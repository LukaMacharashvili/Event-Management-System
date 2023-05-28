using ErrorOr;
using EventMaster.Domain.Tickets;
using MediatR;

namespace EventMaster.Application.Tickets.Commands.CreateTicket;

public record CreateTicketCommand(
    string Type,
    int EventId,
    int HostId) : IRequest<ErrorOr<Ticket>>;
