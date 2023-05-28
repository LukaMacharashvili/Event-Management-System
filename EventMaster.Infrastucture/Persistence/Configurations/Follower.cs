using EventMaster.Domain.Events;
using EventMaster.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventMaster.Infrastructure.Persistence.Configurations;

public class FollowerFollowingConfigurations : IEntityTypeConfiguration<FollowerFollowing>
{
    public void Configure(EntityTypeBuilder<FollowerFollowing> builder)
    {
        ConfigureFollowerFollowingsTable(builder);
    }

    private void ConfigureFollowerFollowingsTable(EntityTypeBuilder<FollowerFollowing> builder)
    {
        builder.HasKey(e => new { e.FollowerId, e.FollowingId });

        builder.HasOne(e => e.Follower)
            .WithMany(e => e.Followings)
            .HasForeignKey(e => e.FollowerId);

        builder.HasOne(e => e.Following)
            .WithMany(e => e.Followers)
            .HasForeignKey(e => e.FollowingId);
    }

}