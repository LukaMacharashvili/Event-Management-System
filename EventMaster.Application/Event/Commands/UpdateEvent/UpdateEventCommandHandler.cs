using EventMaster.Application.Common.Interfaces.Persistence;
using ErrorOr;
using MediatR;
using EventMaster.Domain.Common.DomainErrors;
using EventMaster.Domain.Events;

namespace EventMaster.Application.Events.Commands.UpdateEvent;

public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand, ErrorOr<Event>>
{
    private readonly IEventRepository _eventRepository;

    public UpdateEventCommandHandler(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }

    public async Task<ErrorOr<Event>> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
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

        @event!.Update(
            title: request.Title,
            description: request.Description,
            address: request.Address,
            city: request.City,
            country: request.Country,
            zip: request.Zip,
            state: request.State ?? null,
            everyoneAllowed: request.EveryoneAllowed
        );

        await _eventRepository.UpdateAsync(@event);

        return @event!;
    }
}