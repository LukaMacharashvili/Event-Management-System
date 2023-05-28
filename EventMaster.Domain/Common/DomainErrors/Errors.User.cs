using ErrorOr;

namespace EventMaster.Domain.Common.DomainErrors;

public static partial class Errors
{
    public static class User
    {
        public static Error DuplicateEmail => Error.Conflict(
            code: "User.DuplicateEmail",
            description: "Email is already in use.");

        public static Error CreationFailed => Error.Conflict(
            code: "User.CreationFailed",
            description: "Creation failed.");
    }
}