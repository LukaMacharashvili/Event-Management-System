using FluentValidation;

namespace EventMaster.Application.Topics.Commands.DeleteTopic;

public class DeleteTopicCommandValidator : AbstractValidator<DeleteTopicCommand>
{
    public DeleteTopicCommandValidator()
    {
        RuleFor(x => x.TopicId).NotEmpty();
        RuleFor(x => x.EventId).NotEmpty();
        RuleFor(x => x.HostId).NotEmpty();
    }
}