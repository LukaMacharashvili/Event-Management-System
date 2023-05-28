using EventMaster.Domain.Common.Models;
using EventMaster.Domain.Tickets;
using EventMaster.Domain.Users;

namespace EventMaster.Domain.Reservations;

public sealed class Reservation : IAuditableEntity
{
    public int Id { get; private set; }
    public int TicketId { get; private set; }
    public Ticket Ticket { get; private set; }
    public int GuestId { get; private set; }
    public User Guest { get; private set; }
    public bool Accepted { get; private set; }
    public Guid Secret { get; } = Guid.NewGuid();
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    private Reservation(
        bool accepted,
        Ticket ticket,
        User guest)
    {
        Ticket = ticket;
        Guest = guest;
        Accepted = accepted;
    }

    public static Reservation Create(
        bool accepted,
        Ticket ticket,
        User guest)
    {
        return new Reservation(
            accepted,
            ticket,
            guest);
    }

#pragma warning disable CS8618
    private Reservation()
    {
    }
#pragma warning restore CS8618
}