using EventMaster.Application.Common.Interfaces.Persistence;
using ErrorOr;
using MediatR;
using EventMaster.Domain.Events;

namespace EventMaster.Application.Events.Queries.LoadEvents;

public class LoadEventsQueryHandler : IRequestHandler<LoadEventsQuery, ErrorOr<List<Event>>>
{
    private readonly IEventRepository _eventRepository;

    public LoadEventsQueryHandler(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }

    public async Task<ErrorOr<List<Event>>> Handle(LoadEventsQuery request, CancellationToken cancellationToken)
    {
        return await _eventRepository.LoadAsync();
    }
}