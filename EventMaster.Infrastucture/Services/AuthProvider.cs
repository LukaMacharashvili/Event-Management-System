
using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;
using EventMaster.Application.Common.Interfaces.Services;

namespace EventMaster.Infrastructure.Services;

public class AuthProvider : IAuthProvider
{
    private readonly IAmazonCognitoIdentityProvider _cognitoProvider;
    private string fixUsername(string email)
    {
        return email.Replace("@", "_at_");
    }

    public AuthProvider(IAmazonCognitoIdentityProvider cognitoProvider)
    {
        _cognitoProvider = cognitoProvider;
    }

    public async Task<bool> Create(string clientId, int id, string email, string password)
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
                new AttributeType
                {
                    Name = "custom:id",
                    Value = id.ToString(),
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

    public async Task<AuthenticationResultType> FetchAuthTokens(string clientId, string email, string password)
    {
        var username = fixUsername(email);

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

    public async Task<string> ValidateToken(string accessToken)
    {
        var res = await _cognitoProvider.GetUserAsync(new GetUserRequest
        {
            AccessToken = accessToken,
        });

        return res.UserAttributes.FirstOrDefault(x => x.Name == "custom:id")?.Value ?? "";
    }

    public async Task ConfirmUser(string clientId, string email, string confirmationCode)
    {
        var username = fixUsername(email);

        await _cognitoProvider.ConfirmSignUpAsync(new ConfirmSignUpRequest
        {
            Username = username,
            ClientId = clientId,
            ConfirmationCode = confirmationCode,
        });
    }

}