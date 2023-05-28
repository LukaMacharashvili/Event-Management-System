using ErrorOr;

using MediatR;
using EventMaster.Application.Common.Interfaces.Services;
using EventMaster.Application.Common.Interfaces.Persistence;
using Amazon.CognitoIdentityProvider.Model;

namespace EventMaster.Application.Authentication.Queries.LoginUser;

public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, ErrorOr<AuthenticationResultType>>
{
    private readonly IAuthProvider _authProvider;

    public LoginUserQueryHandler(IAuthProvider authProvider,
        IUserRepository userRepository)
    {
        _authProvider = authProvider;
    }

    public async Task<ErrorOr<AuthenticationResultType>> Handle(LoginUserQuery command, CancellationToken cancellationToken)
    {
        return await _authProvider.FetchAuthTokens(command.ClientId, command.Email, command.Password);
    }
}