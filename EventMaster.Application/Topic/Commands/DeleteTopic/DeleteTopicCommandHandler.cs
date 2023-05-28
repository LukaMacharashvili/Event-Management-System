using EventMaster.Application.Common.Interfaces.Persistence;
using ErrorOr;
using MediatR;
using EventMaster.Domain.Topics;
using EventMaster.Domain.Common.DomainErrors;

namespace EventMaster.Application.Topics.Commands.DeleteTopic;

public class DeleteTopicCommandHandler : IRequestHandler<DeleteTopicCommand, ErrorOr<Topic>>
{
    private readonly IEventRepository _eventRepository;
    private readonly ITopicRepository _topicRepository;
    private readonly IUserRepository _hostRepository;

    public DeleteTopicCommandHandler(IEventRepository eventRepository,
    ITopicRepository topicRepository, IUserRepository hostRepository)
    {
        _eventRepository = eventRepository;
        _topicRepository = topicRepository;
        _hostRepository = hostRepository;
    }

    public async Task<ErrorOr<Topic>> Handle(DeleteTopicCommand request, CancellationToken cancellationToken)
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

        var topic = @event?.Topics?.FirstOrDefault(x => x.Id == request.TopicId);

        if (topic is null)
        {
            return Errors.Topic.TopicNotFound;
        }

        await _topicRepository.DeleteAsync(topic!);

        return topic!;
    }
}