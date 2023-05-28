using FluentValidation;

namespace EventMaster.Application.Topics.Commands.CreateTopic;

public class CreateTopicCommandValidator : AbstractValidator<CreateTopicCommand>
{
    public CreateTopicCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.EventId).NotEmpty();
        RuleFor(x => x.HostId).NotEmpty();
    }
}