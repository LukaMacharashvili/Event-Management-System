using Amazon.CognitoIdentityProvider.Model;
using ErrorOr;
using MediatR;

namespace EventMaster.Application.Authentication.Queries.LoginUser;

public record LoginUserQuery(
    string Email,
    string Password,
    string ClientId) : IRequest<ErrorOr<AuthenticationResultType>>
{
    public LoginUserQuery() : this("", "", "") { }
};
