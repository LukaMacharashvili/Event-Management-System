using ErrorOr;

using MediatR;
using EventMaster.Application.Common.Interfaces.Services;
using EventMaster.Application.Common.Interfaces.Persistence;
using EventMaster.Domain.Common.DomainErrors;
using EventMaster.Domain.Users;

namespace EventMaster.Application.Authentication.Commands.RegisterUser;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, ErrorOr<User>>
{
    private readonly IAuthProvider _authProvider;
    private readonly IUserRepository _userRepository;

    public RegisterUserCommandHandler(IAuthProvider authProvider,
        IUserRepository userRepository)
    {
        _authProvider = authProvider;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<User>> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
    {
        var userExists = await _userRepository.FetchByEmailAsync(command.Email);
        if (userExists is not null)
        {
            return Errors.User.DuplicateEmail;
        }

        var user = await _userRepository.AddAsync(User.Create(command.FirstName,
               command.LastName,
               command.Email));
        await _authProvider.Create(command.ClientId, user!.Id, command.Email, command.Password);

        return user is null
            ? Errors.User.CreationFailed
            : user;
    }
}