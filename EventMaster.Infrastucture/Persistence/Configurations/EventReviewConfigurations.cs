using EventMaster.Domain.EventReviews;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventMaster.Infrastructure.Persistence.Configurations;

public class EventReviewConfigurations : IEntityTypeConfiguration<EventReview>
{
    public void Configure(EntityTypeBuilder<EventReview> builder)
    {
        ConfigureEventReviewsTable(builder);
    }

    private void ConfigureEventReviewsTable(EntityTypeBuilder<EventReview> builder)
    {
        builder.HasOne(e => e.Event)
            .WithMany(e => e.EventReviews)
            .HasForeignKey(a => a.EventId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.Guest)
            .WithMany(e => e.EventsReviews)
            .HasForeignKey(a => a.GuestId)
            .OnDelete(DeleteBehavior.Cascade);
    }

}