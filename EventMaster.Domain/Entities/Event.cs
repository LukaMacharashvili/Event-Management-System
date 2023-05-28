using EventMaster.Domain.Common.Models;
using EventMaster.Domain.EventReviews;
using EventMaster.Domain.Tickets;
using EventMaster.Domain.Topics;
using EventMaster.Domain.Users;

namespace EventMaster.Domain.Events;

public sealed class Event : IAuditableEntity
{
    public int Id { get; private set; }

    private readonly List<EventReview> _eventReviews = new();
    private readonly List<EventHost> _hosts = new();
    private readonly List<Ticket> _tickets = new();
    private readonly List<Topic> _topics = new();
    private readonly List<EventGuest> _guests = new();

    public string Title { get; private set; }
    public string Description { get; private set; }
    public bool EveryoneAllowed { get; private set; }

    public string Address { get; private set; }
    public string City { get; private set; }
    public string? State { get; private set; }
    public string Zip { get; private set; }
    public string Country { get; private set; }

    public IReadOnlyList<EventReview> EventReviews => _eventReviews;
    public IReadOnlyList<EventHost> Hosts => _hosts;
    public IReadOnlyList<Ticket> Tickets => _tickets;
    public IReadOnlyList<EventGuest> Guests => _guests;
    public IReadOnlyList<Topic> Topics => _topics;

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    private Event(
        string title,
        string description,
        string address,
        string city,
        string? state,
        string zip,
        string country,
        bool everyoneAllowed)
    {
        Title = title;
        Description = description;
        Address = address;
        City = city;
        State = state;
        Zip = zip;
        Country = country;
        EveryoneAllowed = everyoneAllowed;
    }

    public static Event Create(
        string title,
        string description,
        string address,
        string city,
        string? state,
        string zip,
        string country,
        bool everyoneAllowed)
    {
        return new Event(
            title,
            description,
            address,
            city,
            state,
            zip,
            country,
            everyoneAllowed);
    }

    public void Update(string? title,
    string? description,
    string? address,
    string? city,
    string? state,
    string? zip,
    string? country,
    bool? everyoneAllowed)
    {
        Title = title ?? Title;
        Description = description ?? Description;
        Address = address ?? Address;
        City = city ?? City;
        State = state ?? State;
        Zip = zip ?? Zip;
        Country = country ?? Country;
        EveryoneAllowed = everyoneAllowed ?? EveryoneAllowed;
    }

    public void AddHost(User host)
    {
        _hosts.Add(new EventHost { Event = this, Host = host });
    }

    public void AddGuest(User guest)
    {
        _guests.Add(new EventGuest { Event = this, Guest = guest });
    }

    public void RemoveGuest(User guest)
    {
        var eventGuest = _guests.FirstOrDefault(x => x.Guest == guest);
        if (eventGuest is not null)
        {
            _guests.Remove(eventGuest);
        }
    }

    public void AddTopic(Topic topic)
    {
        _topics.Add(topic);
    }

#pragma warning disable CS8618
    private Event()
    {
    }
#pragma warning restore CS8618
}