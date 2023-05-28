using ErrorOr;
using EventMaster.Domain.Events;
using MediatR;

namespace EventMaster.Application.Events.Commands.DeleteEvent;

public record DeleteEventCommand(
    int EventId,
    int HostId) : IRequest<ErrorOr<Event>>
{
    public DeleteEventCommand() : this(0, 0) { }
}
