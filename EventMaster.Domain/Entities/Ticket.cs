using EventMaster.Domain.Common.Models;
using EventMaster.Domain.Events;
using EventMaster.Domain.Reservations;

namespace EventMaster.Domain.Tickets;

public sealed class Ticket : IAuditableEntity
{
    public int Id { get; private set; }
    public string Type { get; private set; }
    public int EventId { get; private set; }
    public Event Event { get; private set; }
    public Reservation? Reservation { get; private set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    private Ticket(
        Event @event,
        string type)
    {
        Type = type;
        Event = @event;
    }

    public static Ticket Create(
        Event @event,
        string type)
    {
        return new Ticket(
            @event,
            type);
    }

#pragma warning disable CS8618
    private Ticket()
    {
    }
#pragma warning restore CS8618
}