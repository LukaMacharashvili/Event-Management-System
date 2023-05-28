using ErrorOr;
using MediatR;
using EventMaster.Domain.Events;

namespace EventMaster.Application.Events.Commands.UpdateEvent;

public record UpdateEventCommand(
    int EventId,
    int HostId,
    string? Title,
    string? Description,
    string? Address,
    string? City,
    string? Country,
    string? Zip,
    string? State,
    bool? EveryoneAllowed) : IRequest<ErrorOr<Event>>
{
    public UpdateEventCommand() : this(0, 0, "", "", "", "", "", "", "", false) { }
}

