using System.Security.Claims;
using EventMaster.Api.Common.Mapping;
using EventMaster.Application.Events.Commands.CreateEvent;
using EventMaster.Application.Events.Commands.DeleteEvent;
using EventMaster.Application.Events.Commands.UpdateEvent;
using EventMaster.Application.Events.Queries.FetchEvent;
using EventMaster.Application.Events.Queries.LoadEvents;
using EventMaster.Contracts.Events;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventMaster.Api.Controllers;

[Route("event")]
public class EventController : ApiController
{
    private readonly IMapper _mapper;
    private readonly ISender _mediator;
    private readonly int? UserId;

    public EventController(IMapper mapper, ISender mediator, IHttpContextAccessor httpContextAccessor)
    {
        UserId = int.Parse(httpContextAccessor?.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> LoadEvents()
    {
        var loadEventsResult = await _mediator.Send(new LoadEventsQuery { });

        return loadEventsResult.Match(
            @event => Ok(@event),
            errors => Problem(errors));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> FetchEvent(int id)
    {
        var query = _mapper.Map<FetchEventQuery>(id);

        var loadEventsResult = await _mediator.Send(query);

        return loadEventsResult.Match(
            @event => Ok(@event),
            errors => Problem(errors));
    }


    [HttpPost]
    public async Task<IActionResult> CreateEvent(CreateEventRequest request)
    {
        var command = _mapper.Map<CreateEventCommand>(new CreateEventAndHostId(UserId ?? 0, request));

        var createEventResult = await _mediator.Send(command);

        return createEventResult.Match(
            @event => Ok(@event),
            errors => Problem(errors));
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateEvent(UpdateEventRequest request, int id)
    {
        var command = _mapper.Map<UpdateEventCommand>(new UpdateEventAndHostIdAndEventId(id, UserId ?? 0, request));

        var updateEventResult = await _mediator.Send(command);

        return updateEventResult.Match(
            @event => Ok(@event),
            errors => Problem(errors));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEvent(int id)
    {
        var command = _mapper.Map<DeleteEventCommand>(new DeleteEventAndHostId(id, UserId ?? 0));

        var deleteEventResult = await _mediator.Send(command);

        return deleteEventResult.Match(
            @event => Ok(),
            errors => Problem(errors));
    }
}