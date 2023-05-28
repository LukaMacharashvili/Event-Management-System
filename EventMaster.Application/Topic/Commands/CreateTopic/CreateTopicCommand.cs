using ErrorOr;
using EventMaster.Domain.Topics;
using MediatR;

namespace EventMaster.Application.Topics.Commands.CreateTopic;

public record CreateTopicCommand(
    string Name,
    string Description,
    int EventId,
    int HostId) : IRequest<ErrorOr<Topic>>;
