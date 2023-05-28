using ErrorOr;

namespace EventMaster.Domain.Common.DomainErrors;

public static partial class Errors
{
    public static class Reservation
    {
        public static Error ReservationNotFound => Error.Conflict(
            code: "Reservation.NotFound",
            description: "Reservation not found.");
    }
}