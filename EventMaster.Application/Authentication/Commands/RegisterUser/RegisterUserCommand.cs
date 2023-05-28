using ErrorOr;
using EventMaster.Domain.Users;
using MediatR;

namespace EventMaster.Application.Authentication.Commands.RegisterUser;

public record RegisterUserCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password,
    string ClientId) : IRequest<ErrorOr<User>>
{
    public RegisterUserCommand() : this("", "", "", "", "") { }
};