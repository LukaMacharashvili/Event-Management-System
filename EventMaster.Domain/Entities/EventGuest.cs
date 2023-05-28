using EventMaster.Domain.Users;

namespace EventMaster.Domain.Events;

public sealed class EventGuest
{

    public int EventId { get; set; }
    public required Event Event { get; set; }

    public int GuestId { get; set; }
    public required User Guest { get; set; }
}