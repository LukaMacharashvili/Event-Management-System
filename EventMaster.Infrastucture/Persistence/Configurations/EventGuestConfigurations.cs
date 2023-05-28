using EventMaster.Domain.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventMaster.Infrastructure.Persistence.Configurations;

public class EventGuestConfigurations : IEntityTypeConfiguration<EventGuest>
{
    public void Configure(EntityTypeBuilder<EventGuest> builder)
    {
        ConfigureEventsTable(builder);
    }

    private void ConfigureEventsTable(EntityTypeBuilder<EventGuest> builder)
    {
        builder.HasKey(e => new { e.EventId, e.GuestId });

        builder.HasOne(e => e.Event)
            .WithMany(e => e.Guests)
            .HasForeignKey(e => e.EventId);

        builder.HasOne(e => e.Guest)
            .WithMany(e => e.EventsToAttend)
            .HasForeignKey(e => e.GuestId);
    }

}