using EventMaster.Application.Common.Interfaces.Persistence;
using ErrorOr;
using MediatR;
using EventMaster.Domain.Topics;

namespace EventMaster.Application.Topics.Queries.LoadTopics;

public class LoadTopicsQueryHandler : IRequestHandler<LoadTopicsQuery, ErrorOr<List<Topic>>>
{
    private readonly ITopicRepository _topicRepository;

    public LoadTopicsQueryHandler(ITopicRepository topicRepository)
    {
        _topicRepository = topicRepository;
    }

    public async Task<ErrorOr<List<Topic>>> Handle(LoadTopicsQuery request, CancellationToken cancellationToken)
    {
        return await _topicRepository.LoadAsync(request.EventId);
    }
}