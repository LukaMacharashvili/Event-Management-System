using ErrorOr;

namespace EventMaster.Domain.Common.DomainErrors;

public static partial class Errors
{
    public static class Guest
    {
        public static Error GuestNotFound => Error.NotFound(
            code: "Guest.NotFound",
            description: "Guest not found.");

        public static Error GuestNotAllowed => Error.Conflict(
            code: "Guest.NotAllowed",
            description: "Guest not allowed.");
    }
}