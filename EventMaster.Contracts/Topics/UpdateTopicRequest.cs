namespace EventMaster.Contracts.Topics;

public record UpdateTopicRequest(
    string? Name,
    string? Description);
