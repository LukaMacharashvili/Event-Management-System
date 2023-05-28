using ErrorOr;
using EventMaster.Domain.Events;
using MediatR;

namespace EventMaster.Application.Events.Commands.CreateEvent;

public record CreateEventCommand(
    string Title,
    string Description,
    string Address,
    string City,
    string Country,
    string Zip,
    string? State,
    bool EveryoneAllowed,
    int HostId) : IRequest<ErrorOr<Event>>
{
    public CreateEventCommand() : this("", "", "", "", "", "", "", false, 0) { }
}
