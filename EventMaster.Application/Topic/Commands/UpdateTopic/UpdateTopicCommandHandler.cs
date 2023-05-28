using EventMaster.Application.Common.Interfaces.Persistence;
using ErrorOr;
using MediatR;
using EventMaster.Domain.Common.DomainErrors;
using EventMaster.Domain.Topics;

namespace EventMaster.Application.Topics.Commands.UpdateTopic;

public class UpdateTopicCommandHandler : IRequestHandler<UpdateTopicCommand, ErrorOr<Topic>>
{
    private readonly IEventRepository _eventRepository;
    private readonly ITopicRepository _topicRepository;
    private readonly IUserRepository _hostRepository;

    public UpdateTopicCommandHandler(IEventRepository eventRepository,
    ITopicRepository topicRepository, IUserRepository hostRepository)
    {
        _eventRepository = eventRepository;
        _topicRepository = topicRepository;
        _hostRepository = hostRepository;
    }

    public async Task<ErrorOr<Topic>> Handle(UpdateTopicCommand request, CancellationToken cancellationToken)
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

        topic.Update(request.Name, request.Description);

        await _topicRepository.UpdateAsync(topic!);

        return topic!;
    }
}