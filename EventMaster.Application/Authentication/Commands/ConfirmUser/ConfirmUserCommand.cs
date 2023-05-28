using ErrorOr;
using EventMaster.Domain.Users;
using MediatR;

namespace EventMaster.Application.Authentication.Commands.ConfirmUser;

public record ConfirmUserCommand(
    string Email,
    string Code,
    string ClientId) : IRequest<ErrorOr<bool>>
{
    public ConfirmUserCommand() : this("", "", "") { }
};