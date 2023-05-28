using FluentValidation;

namespace EventMaster.Application.Authentication.Queries.LoginUser;

public class LoginUserQueryValidator : AbstractValidator<LoginUserQuery>
{
    public LoginUserQueryValidator()
    {
        RuleFor(x => x.Email).NotEmpty();
        RuleFor(x => x.Password).NotEmpty();
    }
}