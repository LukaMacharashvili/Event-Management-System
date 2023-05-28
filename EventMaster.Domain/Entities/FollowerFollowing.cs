namespace EventMaster.Domain.Users;

public sealed class FollowerFollowing
{
    public int FollowerId { get; set; }
    public required User Follower { get; set; }

    public int FollowingId { get; set; }
    public required User Following { get; set; }
}