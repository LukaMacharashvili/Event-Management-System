using FluentValidation;

namespace EventMaster.Application.Events.Commands.CreateEvent;

public class CreateEventCommandValidator : AbstractValidator<CreateEventCommand>
{
    public CreateEventCommandValidator()
    {
        RuleFor(x => x.Title).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.Address).NotEmpty();
        RuleFor(x => x.City).NotEmpty();
        RuleFor(x => x.Country).NotEmpty();
        RuleFor(x => x.Zip).NotEmpty();
        RuleFor(x => x.EveryoneAllowed).NotNull();
    }
}