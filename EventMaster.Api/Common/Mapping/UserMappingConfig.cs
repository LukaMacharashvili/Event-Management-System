using Mapster;
using EventMaster.Application.Authentication.Commands.RegisterUser;
using EventMaster.Contracts.Authentication;
using EventMaster.Application.Authentication.Queries.LoginUser;
using EventMaster.Application.Authentication.Commands.ConfirmUser;

namespace EventMaster.Api.Common.Mapping;

public class UserMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterUserRequest, RegisterUserCommand>();
        config.NewConfig<LoginUserRequest, LoginUserQuery>();
        config.NewConfig<ConfirmUserAndEmailAndCodeAndClientId, ConfirmUserCommand>()
            .Map(dest => dest.Email, src => src.Email)
            .Map(dest => dest.Code, src => src.Code)
            .Map(dest => dest.ClientId, src => src.ClientId);
    }
}

public record ConfirmUserAndEmailAndCodeAndClientId(string Email, string Code, string ClientId);