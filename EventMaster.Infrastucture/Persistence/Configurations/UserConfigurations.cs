using EventMaster.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventMaster.Infrastructure.Persistence.Configurations;

public class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        ConfigureUsersTable(builder);
    }

    private void ConfigureUsersTable(EntityTypeBuilder<User> builder)
    {
        builder.HasMany(e => e.EventsToAttend)
                    .WithOne(e => e.Guest)
                    .HasForeignKey(e => e.GuestId);

        builder.HasMany(e => e.EventsToHost)
                    .WithOne(e => e.Host)
                    .HasForeignKey(e => e.HostId);

        builder.HasMany(e => e.Followers)
                    .WithOne(e => e.Following)
                    .HasForeignKey(e => e.FollowingId);

        builder.HasMany(e => e.Followings)
                    .WithOne(e => e.Follower)
                    .HasForeignKey(e => e.FollowerId);
    }

}