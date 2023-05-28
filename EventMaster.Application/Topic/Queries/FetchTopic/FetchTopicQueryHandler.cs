using EventMaster.Application.Common.Interfaces.Persistence;
using ErrorOr;
using MediatR;
using EventMaster.Domain.Common.DomainErrors;
using EventMaster.Domain.Topics;

namespace EventMaster.Application.Topics.Queries.FetchTopic;

public class FetchTopicQueryHandler : IRequestHandler<FetchTopicQuery, ErrorOr<Topic>>
{
    private readonly ITopicRepository _topicRepository;

    public FetchTopicQueryHandler(ITopicRepository topicRepository)
    {
        _topicRepository = topicRepository;
    }

    public async Task<ErrorOr<Topic>> Handle(FetchTopicQuery request, CancellationToken cancellationToken)
    {
        var topic = await _topicRepository.FetchAsync(request.TopicId);

        if (topic is null)
        {
            return Errors.Event.EventNotFound;
        }

        return topic;
    }
}