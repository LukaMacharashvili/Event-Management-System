using FluentValidation;

namespace EventMaster.Application.Events.Commands.UpdateEvent;

public class UpdateEventCommandValidator : AbstractValidator<UpdateEventCommand>
{
    public UpdateEventCommandValidator()
    {
        RuleFor(x => x.EventId).NotEmpty();
        RuleFor(x => x.HostId).NotEmpty();
    }
}