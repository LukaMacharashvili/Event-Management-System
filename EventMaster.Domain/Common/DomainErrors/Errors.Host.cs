using ErrorOr;

namespace EventMaster.Domain.Common.DomainErrors;

public static partial class Errors
{
    public static class Host
    {
        public static Error HostNotAllowed => Error.Custom(
            type: 403,
            code: "Host.NotAllowed",
            description: "Host not allowed.");

        public static Error HostNotFound => Error.NotFound(
            code: "Host.NotFound",
            description: "Host not found.");
    }
}