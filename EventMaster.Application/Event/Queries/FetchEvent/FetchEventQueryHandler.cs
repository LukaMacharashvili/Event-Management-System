using EventMaster.Application.Common.Interfaces.Persistence;
using ErrorOr;
using MediatR;
using EventMaster.Domain.Events;
using EventMaster.Domain.Common.DomainErrors;

namespace EventMaster.Application.Events.Queries.FetchEvent;

public class FetchEventQueryHandler : IRequestHandler<FetchEventQuery, ErrorOr<Event>>
{
    private readonly IEventRepository _eventRepository;

    public FetchEventQueryHandler(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }

    public async Task<ErrorOr<Event>> Handle(FetchEventQuery request, CancellationToken cancellationToken)
    {
        var @event = await _eventRepository.FetchAsync(request.EventId);

        if (@event is null)
        {
            return Errors.Event.EventNotFound;
        }

        return @event;
    }
}