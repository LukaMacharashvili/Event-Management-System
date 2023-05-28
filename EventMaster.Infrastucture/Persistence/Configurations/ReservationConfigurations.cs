using EventMaster.Domain.Reservations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventMaster.Infrastructure.Persistence.Configurations;

public class ReservationConfigurations : IEntityTypeConfiguration<Reservation>
{
    public void Configure(EntityTypeBuilder<Reservation> builder)
    {
        ConfigureReservationsTable(builder);
    }

    private void ConfigureReservationsTable(EntityTypeBuilder<Reservation> builder)
    {
        builder.HasOne(e => e.Guest)
            .WithMany(e => e.Reservations)
            .HasForeignKey(a => a.GuestId)
            .OnDelete(DeleteBehavior.Cascade);
    }

}