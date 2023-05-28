using ErrorOr;
using EventMaster.Domain.Topics;
using MediatR;

namespace EventMaster.Application.Topics.Commands.DeleteTopic;

public record DeleteTopicCommand(
    int TopicId,
    int EventId,
    int HostId) : IRequest<ErrorOr<Topic>>;
