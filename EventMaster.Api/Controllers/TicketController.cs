using System.Security.Claims;
using EventMaster.Api.Common.Mapping;
using EventMaster.Application.Tickets.Commands.CreateTicket;
using EventMaster.Application.Tickets.Commands.DeleteTicket;
using EventMaster.Application.Tickets.Queries.FetchTicket;
using EventMaster.Application.Tickets.Queries.LoadTickets;
using EventMaster.Contracts.Tickets;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventMaster.Api.Controllers;

[Route("event/{eventid}/ticket")]
public class TicketController : ApiController
{
    private readonly IMapper _mapper;
    private readonly ISender _mediator;
    private readonly int? UserId;

    public TicketController(IMapper mapper, ISender mediator, IHttpContextAccessor httpContextAccessor)
    {
        UserId = int.Parse(httpContextAccessor?.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> LoadTickets(int eventid)
    {
        var query = _mapper.Map<LoadTicketsQuery>(eventid);

        var loadTicketsResult = await _mediator.Send(query);

        return loadTicketsResult.Match(
            ticket => Ok(ticket),
            errors => Problem(errors));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> FetchTicket(int id)
    {
        var query = _mapper.Map<FetchTicketQuery>(id);

        var loadTicketsResult = await _mediator.Send(query);

        return loadTicketsResult.Match(
            ticket => Ok(ticket),
            errors => Problem(errors));
    }


    [HttpPost]
    public async Task<IActionResult> CreateTicket(CreateTicketRequest request, int eventid)
    {
        var command = _mapper.Map<CreateTicketCommand>(new CreateTicketAndHostIdAndEventId(UserId ?? 0, eventid, request));

        var createTicketResult = await _mediator.Send(command);

        return createTicketResult.Match(
            ticket => Ok(ticket),
            errors => Problem(errors));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTicket(int id, int eventid)
    {
        var command = _mapper.Map<DeleteTicketCommand>(new DeleteTicketAndHostIdAndEventId(id, UserId ?? 0, eventid));

        var deleteTicketResult = await _mediator.Send(command);

        return deleteTicketResult.Match(
            ticket => Ok(),
            errors => Problem(errors));
    }
}