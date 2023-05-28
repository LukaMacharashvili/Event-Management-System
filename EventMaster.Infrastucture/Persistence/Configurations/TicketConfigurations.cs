using EventMaster.Domain.Reservations;
using EventMaster.Domain.Tickets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventMaster.Infrastructure.Persistence.Configurations;

public class TicketConfigurations : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        ConfigureTicketsTable(builder);
    }

    private void ConfigureTicketsTable(EntityTypeBuilder<Ticket> builder)
    {
        builder.HasOne(e => e.Event)
                .WithMany(e => e.Tickets)
                .HasForeignKey(a => a.EventId)
                .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.Reservation)
                .WithOne(e => e.Ticket)
                .HasForeignKey<Reservation>(r => r.TicketId)
                .OnDelete(DeleteBehavior.NoAction);
    }

}