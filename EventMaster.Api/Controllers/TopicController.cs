using System.Security.Claims;
using EventMaster.Api.Common.Mapping;
using EventMaster.Application.Topics.Commands.CreateTopic;
using EventMaster.Application.Topics.Commands.DeleteTopic;
using EventMaster.Application.Topics.Commands.UpdateTopic;
using EventMaster.Application.Topics.Queries.FetchTopic;
using EventMaster.Application.Topics.Queries.LoadTopics;
using EventMaster.Contracts.Topics;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventMaster.Api.Controllers;

[Route("event/{eventid}/topic")]
public class TopicController : ApiController
{
    private readonly IMapper _mapper;
    private readonly ISender _mediator;
    private readonly int? UserId;

    public TopicController(IMapper mapper, ISender mediator, IHttpContextAccessor httpContextAccessor)
    {
        UserId = int.Parse(httpContextAccessor?.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> LoadTopics(int eventid)
    {
        var query = _mapper.Map<LoadTopicsQuery>(eventid);

        var loadTopicsResult = await _mediator.Send(query);

        return loadTopicsResult.Match(
            topic => Ok(topic),
            errors => Problem(errors));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> FetchTopic(int id)
    {
        var query = _mapper.Map<FetchTopicQuery>(id);

        var loadTopicsResult = await _mediator.Send(query);

        return loadTopicsResult.Match(
            topic => Ok(topic),
            errors => Problem(errors));
    }


    [HttpPost]
    public async Task<IActionResult> CreateTopic(CreateTopicRequest request, int eventid)
    {
        var command = _mapper.Map<CreateTopicCommand>(new CreateTopicAndHostIdAndEventId(UserId ?? 0, eventid, request));

        var createTopicResult = await _mediator.Send(command);

        return createTopicResult.Match(
            topic => Ok(topic),
            errors => Problem(errors));
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateTopic(UpdateTopicRequest request, int eventid, int id)
    {
        var command = _mapper.Map<UpdateTopicCommand>(new UpdateTopicAndHostIdAndEventIdAndTopicId(UserId ?? 0, eventid, id, request));

        var updateTopicResult = await _mediator.Send(command);

        return updateTopicResult.Match(
            topic => Ok(topic),
            errors => Problem(errors));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTopic(int eventid, int id)
    {
        var command = _mapper.Map<DeleteTopicCommand>(new DeleteTopicAndHostIdAndEventIdAndTopicId(UserId ?? 0, eventid, id));

        var deleteTopicResult = await _mediator.Send(command);

        return deleteTopicResult.Match(
            topic => Ok(),
            errors => Problem(errors));
    }
}