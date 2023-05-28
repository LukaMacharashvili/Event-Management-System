using EventMaster.Domain.Users;

namespace EventMaster.Domain.Events;

public sealed class EventHost
{

    public int EventId { get; set; }
    public required Event Event { get; set; }

    public int HostId { get; set; }
    public required User Host { get; set; }
}