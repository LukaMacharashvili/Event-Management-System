using EventMaster.Contracts.Authentication;
using EventMaster.Domain.Common.DomainErrors;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EventMaster.Application.Authentication.Commands.RegisterUser;
using EventMaster.Application.Authentication.Queries.LoginUser;
using EventMaster.Application.Authentication.Commands.ConfirmUser;
using EventMaster.Api.Common.Mapping;

namespace EventMaster.Api.Controllers;

[Route("auth")]
[AllowAnonymous]
public class AuthenticationController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public AuthenticationController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterUserRequest request)
    {
        var command = _mapper.Map<RegisterUserCommand>(request);
        var authResult = await _mediator.Send(command);

        return authResult.Match(
            authResult => Ok(authResult),
            errors => Problem(errors));
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginUserRequest request)
    {
        var query = _mapper.Map<LoginUserQuery>(request);
        var authResult = await _mediator.Send(query);

        if (authResult.IsError && authResult.FirstError == Errors.Authentication.InvalidCredentials)
        {
            return Problem(
                statusCode: StatusCodes.Status401Unauthorized,
                title: authResult.FirstError.Description);
        }

        return authResult.Match(
            authResult => Ok(authResult),
            errors => Problem(errors));
    }

    [HttpPost("confirm")]
    public async Task<IActionResult> ConfirmUser([FromQuery(Name = "email")] string email, [FromQuery(Name = "clientid")] string clientId, [FromQuery(Name = "code")] string code)
    {
        var command = _mapper.Map<ConfirmUserCommand>(new ConfirmUserAndEmailAndCodeAndClientId(email, code, clientId));
        var res = await _mediator.Send(command);

        return res.Match(
            res => Ok(res),
            errors => Problem(errors));
    }
}