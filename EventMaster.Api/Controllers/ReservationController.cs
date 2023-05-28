using System.Security.Claims;
using EventMaster.Api.Common.Mapping;
using EventMaster.Application.Reservations.Commands.CreateReservation;
using EventMaster.Application.Reservations.Commands.DeleteReservation;
using EventMaster.Application.Reservations.Queries.FetchReservation;
using EventMaster.Application.Reservations.Queries.LoadReservations;
using EventMaster.Contracts.Reservations;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventMaster.Api.Controllers;

[Route("guest/{guestid}/reservation")]
public class ReservationController : ApiController
{
    private readonly IMapper _mapper;
    private readonly ISender _mediator;
    private readonly int? UserId;

    public ReservationController(IMapper mapper, ISender mediator, IHttpContextAccessor httpContextAccessor)
    {
        UserId = int.Parse(httpContextAccessor?.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> LoadReservations(int guestid)
    {
        var query = _mapper.Map<LoadReservationsQuery>(guestid);

        var loadReservationsResult = await _mediator.Send(query);

        return loadReservationsResult.Match(
            reservation => Ok(reservation),
            errors => Problem(errors));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> FetchReservation(int id)
    {
        var query = _mapper.Map<FetchReservationQuery>(id);

        var loadReservationsResult = await _mediator.Send(query);

        return loadReservationsResult.Match(
            reservation => Ok(reservation),
            errors => Problem(errors));
    }


    [HttpPost]
    public async Task<IActionResult> CreateReservation(CreateReservationRequest request, int eventid)
    {
        var command = _mapper.Map<CreateReservationCommand>(new CreateReservationAndGuestIdAndTicketId(UserId ?? 0, request));

        var createReservationResult = await _mediator.Send(command);

        return createReservationResult.Match(
            reservation => Ok(reservation),
            errors => Problem(errors));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteReservation(int id, int eventid)
    {
        var command = _mapper.Map<DeleteReservationCommand>(new DeleteReservationAndGuestIdAndEventId(id, UserId ?? 0, eventid));

        var deleteReservationResult = await _mediator.Send(command);

        return deleteReservationResult.Match(
            reservation => Ok(),
            errors => Problem(errors));
    }
}