using ErrorOr;

namespace EventMaster.Domain.Common.DomainErrors;

public static partial class Errors
{
    public static class Ticket
    {
        public static Error TicketNotFound => Error.NotFound(
            code: "Ticket.NotFound",
            description: "Ticket not found.");
    }
}