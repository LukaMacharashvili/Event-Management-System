using FluentValidation;

namespace EventMaster.Application.Topics.Commands.UpdateTopic;

public class UpdateTopicCommandValidator : AbstractValidator<UpdateTopicCommand>
{
    public UpdateTopicCommandValidator()
    {
        RuleFor(x => x.TopicId).NotEmpty();
        RuleFor(x => x.EventId).NotEmpty();
        RuleFor(x => x.HostId).NotEmpty();
    }
}