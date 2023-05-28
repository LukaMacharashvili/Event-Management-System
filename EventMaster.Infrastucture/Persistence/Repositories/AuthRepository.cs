
using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;

namespace EventMaster.Infrastructure.Persistence.Repositories;

public class AuthRepository
{
    private readonly IAmazonCognitoIdentityProvider _cognitoProvider;
    private string fixUsername(string email)
    {
        return email.Replace("@", "_at_");
    }

    public AuthRepository(IAmazonCognitoIdentityProvider cognitoProvider)
    {
        _cognitoProvider = cognitoProvider;
    }

    public async Task<bool> Create(string clientId, string email, string password)
    {
        var username = fixUsername(email);

        var signUpRes = await _cognitoProvider.SignUpAsync(new SignUpRequest
        {
            ClientId = clientId,
            Username = username,
            Password = password,
            UserAttributes = new List<AttributeType>
            {
                new AttributeType
                {
                    Name = "email",
                    Value = email,
                },
            }
        });

        return signUpRes.UserConfirmed;
    }

    public async Task Delete(string accessToken)
    {
        await _cognitoProvider.DeleteUserAsync(new DeleteUserRequest
        {
            AccessToken = accessToken,
        });
    }

    public async Task<AuthenticationResultType> FetchAuthTokens(string clientId, string username, string password)
    {
        var authRes = await _cognitoProvider.InitiateAuthAsync(new InitiateAuthRequest
        {
            ClientId = clientId,
            AuthFlow = AuthFlowType.USER_PASSWORD_AUTH,
            AuthParameters = new Dictionary<string, string>
            {
                { "USERNAME", username },
                { "PASSWORD", password },
            }
        });

        return authRes.AuthenticationResult;
    }

}