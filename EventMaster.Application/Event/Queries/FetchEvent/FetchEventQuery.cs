using ErrorOr;
using EventMaster.Domain.Events;
using MediatR;

namespace EventMaster.Application.Events.Queries.FetchEvent;

public record FetchEventQuery(int EventId) : IRequest<ErrorOr<Event>>
{
    public FetchEventQuery() : this(0) { }
}
