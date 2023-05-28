using EventMaster.Domain.Common.Models;
using EventMaster.Domain.EventReviews;
using EventMaster.Domain.Events;
using EventMaster.Domain.Reservations;

namespace EventMaster.Domain.Users;

public sealed class User : IAuditableEntity
{
    public int Id { get; private set; }

    private readonly List<EventHost> _eventsToHost = new();
    private readonly List<EventGuest> _eventsToAttend = new();
    private readonly List<EventReview> _eventsReviews = new();
    private readonly List<Reservation> _reservations = new();
    private readonly List<FollowerFollowing> _followings = new();
    private readonly List<FollowerFollowing> _followers = new();

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }

    public IReadOnlyList<EventHost> EventsToHost => _eventsToHost;
    public IReadOnlyList<EventGuest> EventsToAttend => _eventsToAttend;
    public IReadOnlyList<EventReview> EventsReviews => _eventsReviews;
    public IReadOnlyList<Reservation> Reservations => _reservations;
    public IReadOnlyList<FollowerFollowing> Followings => _followings;
    public IReadOnlyList<FollowerFollowing> Followers => _followers;

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    private User(
        string firstName,
        string lastName,
        string email)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }

    public static User Create(
        string firstName,
        string lastName,
        string email)
    {
        return new User(
            firstName,
            lastName,
            email);
    }

#pragma warning disable CS8618
    private User()
    {
    }
#pragma warning restore CS8618
}