using System.Security.Claims;
using EventMaster.Api.Common.Mapping;
using EventMaster.Application.EventReviews.Commands.CreateEventReview;
using EventMaster.Application.EventReviews.Commands.DeleteEventReview;
using EventMaster.Application.EventReviews.Commands.UpdateEventReview;
using EventMaster.Application.EventReviews.Queries.FetchEventReview;
using EventMaster.Application.EventReviews.Queries.LoadEventReviews;
using EventMaster.Contracts.EventReviews;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventMaster.Api.Controllers;

[Route("event/{eventid}/event-review")]
public class EventReviewController : ApiController
{
    private readonly IMapper _mapper;
    private readonly ISender _mediator;
    private readonly int? UserId;

    public EventReviewController(IMapper mapper, ISender mediator, IHttpContextAccessor httpContextAccessor)
    {
        UserId = int.Parse(httpContextAccessor?.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> LoadEventReviews(int eventid)
    {
        var query = _mapper.Map<LoadEventReviewsQuery>(eventid);

        var loadEventReviewsResult = await _mediator.Send(query);

        return loadEventReviewsResult.Match(
            eventReview => Ok(eventReview),
            errors => Problem(errors));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> FetchEventReview(int id)
    {
        var query = _mapper.Map<FetchEventReviewQuery>(id);

        var loadEventReviewsResult = await _mediator.Send(query);

        return loadEventReviewsResult.Match(
            eventReview => Ok(eventReview),
            errors => Problem(errors));
    }


    [HttpPost]
    public async Task<IActionResult> CreateEventReview(CreateEventReviewRequest request, int eventid)
    {
        var command = _mapper.Map<CreateEventReviewCommand>(new CreateEventReviewAndGuestIdAndEventId(UserId ?? 0, eventid, request));

        var createEventReviewResult = await _mediator.Send(command);

        return createEventReviewResult.Match(
            eventReview => Ok(eventReview),
            errors => Problem(errors));
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateEventReview(UpdateEventReviewRequest request, int id)
    {
        var command = _mapper.Map<UpdateEventReviewCommand>(new UpdateEventReviewAndGuestIdAndEventReviewId(id, UserId ?? 0, request));

        var updateEventReviewResult = await _mediator.Send(command);

        return updateEventReviewResult.Match(
            eventReview => Ok(eventReview),
            errors => Problem(errors));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEventReview(int id)
    {
        var command = _mapper.Map<DeleteEventReviewCommand>(new DeleteEventReviewAndGuestId(id, UserId ?? 0));

        var deleteEventReviewResult = await _mediator.Send(command);

        return deleteEventReviewResult.Match(
            eventReview => Ok(),
            errors => Problem(errors));
    }
}