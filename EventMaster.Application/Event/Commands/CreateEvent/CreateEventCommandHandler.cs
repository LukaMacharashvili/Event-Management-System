using EventMaster.Application.Common.Interfaces.Persistence;
using EventMaster.Domain.Events;
using ErrorOr;
using MediatR;
using EventMaster.Domain.Common.DomainErrors;

namespace EventMaster.Application.Events.Commands.CreateEvent;

public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, ErrorOr<Event>>
{
    private readonly IEventRepository _eventRepository;
    private readonly IUserRepository _hostRepository;

    public CreateEventCommandHandler(IEventRepository eventRepository,
    IUserRepository hostRepository)
    {
        _eventRepository = eventRepository;
        _hostRepository = hostRepository;
    }

    public async Task<ErrorOr<Event>> Handle(CreateEventCommand request, CancellationToken cancellationToken)
    {
        var host = await _hostRepository.FetchAsync(request.HostId);
        if (host is null)
        {
            return Errors.Host.HostNotFound;
        }

        var @event = Event.Create(
            title: request.Title,
            description: request.Description,
            address: request.Address,
            city: request.City,
            country: request.Country,
            zip: request.Zip,
            state: request.State ?? null,
            everyoneAllowed: request.EveryoneAllowed
        );

        @event.AddHost(host);

        await _eventRepository.AddAsync(@event);

        return @event;
    }
}