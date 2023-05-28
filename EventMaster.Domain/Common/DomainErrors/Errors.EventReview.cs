using ErrorOr;

namespace EventMaster.Domain.Common.DomainErrors;

public static partial class Errors
{
    public static class EventReview
    {
        public static Error EventReviewNotFound => Error.NotFound(
            code: "EventReview.NotFound",
            description: "Event review not found.");
    }
}