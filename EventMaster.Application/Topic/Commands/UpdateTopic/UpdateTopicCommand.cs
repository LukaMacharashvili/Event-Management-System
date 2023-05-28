using ErrorOr;
using MediatR;
using EventMaster.Domain.Topics;

namespace EventMaster.Application.Topics.Commands.UpdateTopic;

public record UpdateTopicCommand(
    int TopicId,
    int HostId,
    int EventId,
    string? Name,
    string? Description) : IRequest<ErrorOr<Topic>>;
