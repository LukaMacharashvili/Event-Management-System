using ErrorOr;

namespace EventMaster.Domain.Common.DomainErrors;

public static partial class Errors
{
    public static class Topic
    {
        public static Error TopicNotFound => Error.NotFound(
            code: "Topic.NotFound",
            description: "Topic not found.");
    }
}