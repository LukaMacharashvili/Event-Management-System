using ErrorOr;
using EventMaster.Domain.Topics;
using MediatR;

namespace EventMaster.Application.Topics.Queries.LoadTopics;

public record LoadTopicsQuery(int EventId) : IRequest<ErrorOr<List<Topic>>>;
