using EventMaster.Application.Common.Interfaces.Persistence;
using ErrorOr;
using MediatR;
using EventMaster.Domain.Events;
using EventMaster.Domain.Common.DomainErrors;

namespace EventMaster.Application.Events.Commands.DeleteEvent;

public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand, ErrorOr<Event>>
{
    private readonly IEventRepository _eventRepository;

    public DeleteEventCommandHandler(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }

    public async Task<ErrorOr<Event>> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
    {
        var @event = await _eventRepository.FetchAsync(request.EventId);

        if (@event is null)
        {
            return Errors.Event.EventNotFound;
        }

        if (@event?.Hosts?.FirstOrDefault(x => x.HostId == request.HostId) is null)
        {
            return Errors.Host.HostNotFound;
        }

        await _eventRepository.DeleteAsync(@event!);

        return @event!;
    }
}