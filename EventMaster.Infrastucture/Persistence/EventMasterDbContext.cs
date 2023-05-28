using EventMaster.Domain.Events;
using EventMaster.Domain.EventReviews;
using EventMaster.Domain.Reservations;
using EventMaster.Domain.Tickets;
using EventMaster.Domain.Users;
using Microsoft.EntityFrameworkCore;
using EventMaster.Domain.Topics;

namespace EventMaster.Infrastructure.Persistence;

public class EventMasterDbContext : DbContext
{
    public EventMasterDbContext(DbContextOptions<EventMasterDbContext> options)
        : base(options)
    {
    }

    public DbSet<Event> Events { get; set; } = null!;
    public DbSet<EventReview> EventReviews { get; set; } = null!;
    public DbSet<Reservation> Reservations { get; set; } = null!;
    public DbSet<Ticket> Tickets { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Topic> Topics { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfigurationsFromAssembly(typeof(EventMasterDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }

}