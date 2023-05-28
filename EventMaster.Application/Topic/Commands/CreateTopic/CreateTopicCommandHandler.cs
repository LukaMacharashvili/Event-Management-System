using EventMaster.Application.Common.Interfaces.Persistence;
using ErrorOr;
using MediatR;
using EventMaster.Domain.Common.DomainErrors;
using EventMaster.Domain.Topics;

namespace EventMaster.Application.Topics.Commands.CreateTopic;

public class CreateTopicCommandHandler : IRequestHandler<CreateTopicCommand, ErrorOr<Topic>>
{
    private readonly IEventRepository _eventRepository;
    private readonly ITopicRepository _topicRepository;
    private readonly IUserRepository _hostRepository;

    public CreateTopicCommandHandler(IEventRepository eventRepository,
    ITopicRepository topicRepository, IUserRepository hostRepository)
    {
        _eventRepository = eventRepository;
        _topicRepository = topicRepository;
        _hostRepository = hostRepository;
    }

    public async Task<ErrorOr<Topic>> Handle(CreateTopicCommand request, CancellationToken cancellationToken)
    {
        var @event = await _eventRepository.FetchAsync(request.EventId);
        if (@event is null)
        {
            return Errors.Event.EventNotFound;
        }

        var host = await _hostRepository.FetchAsync(request.HostId);
        if (@event is null)
        {
            return Errors.Host.HostNotFound;
        }

        if (@event?.Hosts?.FirstOrDefault(x => x.HostId == request.HostId) is null)
        {
            return Errors.Host.HostNotAllowed;
        }

        var topic = Topic.Create(
            name: request.Name,
            description: request.Description,
            @event
        );

        await _topicRepository.AddAsync(topic);

        return topic;
    }
}