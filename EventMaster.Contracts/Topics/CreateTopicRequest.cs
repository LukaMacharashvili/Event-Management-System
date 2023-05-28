namespace EventMaster.Contracts.Topics;

public record CreateTopicRequest(
    string Name,
    string Description);
