using ErrorOr;

namespace EventMaster.Domain.Common.DomainErrors;

public static partial class Errors
{
    public static class Event
    {
        public static Error EventNotFound => Error.NotFound(
            code: "Event.NotFound",
            description: "Event not found.");
    }
}