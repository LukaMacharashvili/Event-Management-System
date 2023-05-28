using EventMaster.Domain.Common.Models;
using EventMaster.Domain.Events;
using EventMaster.Domain.Users;

namespace EventMaster.Domain.EventReviews;

public sealed class EventReview : IAuditableEntity
{
    public int Id { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public int Stars { get; private set; }
    public int GuestId { get; private set; }
    public User Guest { get; private set; }
    public int EventId { get; private set; }
    public Event Event { get; private set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    private EventReview(
        User guest,
        Event @event,
        string title,
        string description,
        int stars)
    {
        Guest = guest;
        Event = @event;
        Title = title;
        Description = description;
        Stars = stars;
    }

    public static EventReview Create(
        User guest,
        Event @event,
        string title,
        string description,
        int stars)
    {
        return new EventReview(
            guest,
            @event,
            title,
            description,
            stars);
    }

    public void Update(
        string? title,
        string? description,
        int? stars)
    {
        Title = title ?? Title;
        Description = description ?? Description;
        Stars = stars ?? Stars;
    }

#pragma warning disable CS8618
    private EventReview()
    {
    }
#pragma warning restore CS8618
}