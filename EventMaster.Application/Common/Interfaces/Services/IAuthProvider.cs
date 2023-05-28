using Amazon.CognitoIdentityProvider.Model;

namespace EventMaster.Application.Common.Interfaces.Services;

public interface IAuthProvider
{
    Task<bool> Create(string clientId, int id, string email, string password);

    Task Delete(string accessToken);

    Task<AuthenticationResultType> FetchAuthTokens(string clientId, string email, string password);

    Task<string> ValidateToken(string token);

    Task ConfirmUser(string clientId, string email, string confirmationCode);
}