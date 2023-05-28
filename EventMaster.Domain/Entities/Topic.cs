using EventMaster.Domain.Common.Models;
using EventMaster.Domain.Events;

namespace EventMaster.Domain.Topics;

public sealed class Topic : IAuditableEntity
{
    public int Id { get; private set; }

    public string Name { get; private set; }
    public string Description { get; private set; }

    public int EventId { get; private set; }
    public Event Event { get; private set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    private Topic(string name,
        string description,
        Event @event)
    {
        Name = name;
        Description = description;
        Event = @event;
    }

    public static Topic Create(
        string name,
        string description,
        Event @event)
    {
        return new Topic(name, description, @event);
    }

    public void Update(string? name,
        string? description)
    {
        Name = name ?? Name;
        Description = description ?? Description;
    }

#pragma warning disable CS8618
    private Topic()
    {
    }
#pragma warning restore CS8618
}