using FluentValidation;

namespace EventMaster.Application.Topics.Queries.FetchTopic;

public class FetchTopicQueryValidator : AbstractValidator<FetchTopicQuery>
{
    public FetchTopicQueryValidator()
    {
        RuleFor(x => x.TopicId).NotEmpty();
    }
}