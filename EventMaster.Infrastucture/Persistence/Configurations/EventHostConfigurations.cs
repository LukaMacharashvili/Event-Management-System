using EventMaster.Domain.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventMaster.Infrastructure.Persistence.Configurations;

public class EventHostConfigurations : IEntityTypeConfiguration<EventHost>
{
    public void Configure(EntityTypeBuilder<EventHost> builder)
    {
        ConfigureEventHostsTable(builder);
    }

    private void ConfigureEventHostsTable(EntityTypeBuilder<EventHost> builder)
    {
        builder.HasKey(e => new { e.EventId, e.HostId });

        builder.HasOne(e => e.Event)
            .WithMany(e => e.Hosts)
            .HasForeignKey(e => e.EventId);

        builder.HasOne(e => e.Host)
            .WithMany(e => e.EventsToHost)
            .HasForeignKey(e => e.HostId);
    }

}