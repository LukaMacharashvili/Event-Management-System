using ErrorOr;

using MediatR;
using EventMaster.Application.Common.Interfaces.Services;

namespace EventMaster.Application.Authentication.Commands.ConfirmUser;

public class ConfirmUserCommandHandler : IRequestHandler<ConfirmUserCommand, ErrorOr<bool>>
{
    private readonly IAuthProvider _authProvider;

    public ConfirmUserCommandHandler(IAuthProvider authProvider)
    {
        _authProvider = authProvider;
    }

    public async Task<ErrorOr<bool>> Handle(ConfirmUserCommand command, CancellationToken cancellationToken)
    {
        await _authProvider.ConfirmUser(command.Code, command.Email, command.ClientId);
        return true;
    }
}