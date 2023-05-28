using ErrorOr;
using EventMaster.Domain.Topics;
using MediatR;

namespace EventMaster.Application.Topics.Queries.FetchTopic;

public record FetchTopicQuery(int TopicId) : IRequest<ErrorOr<Topic>>;
