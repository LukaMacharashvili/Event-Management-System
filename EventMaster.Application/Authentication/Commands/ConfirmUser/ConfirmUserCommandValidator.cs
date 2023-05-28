using FluentValidation;

namespace EventMaster.Application.Authentication.Commands.ConfirmUser;

public class ConfirmUserCommandValidator : AbstractValidator<ConfirmUserCommand>
{
    public ConfirmUserCommandValidator()
    {
        RuleFor(x => x.Email).NotEmpty();
        RuleFor(x => x.ClientId).NotEmpty();
        RuleFor(x => x.Code).NotEmpty();
    }
}