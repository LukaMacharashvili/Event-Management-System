using ErrorOr;
using EventMaster.Domain.Events;
using MediatR;

namespace EventMaster.Application.Events.Queries.LoadEvents;

public record LoadEventsQuery() : IRequest<ErrorOr<List<Event>>>;
