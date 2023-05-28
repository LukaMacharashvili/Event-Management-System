using EventMaster.Domain.Topics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventMaster.Infrastructure.Persistence.Configurations;

public class TopicConfigurations : IEntityTypeConfiguration<Topic>
{
    public void Configure(EntityTypeBuilder<Topic> builder)
    {
        ConfigureEventsTable(builder);
    }

    private void ConfigureEventsTable(EntityTypeBuilder<Topic> builder)
    {
        builder.HasOne(e => e.Event)
            .WithMany(e => e.Topics)
            .HasForeignKey(a => a.EventId)
            .OnDelete(DeleteBehavior.Cascade);
    }

}