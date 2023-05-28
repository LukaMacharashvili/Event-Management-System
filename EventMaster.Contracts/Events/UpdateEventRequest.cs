namespace EventMaster.Contracts.Events;

public record UpdateEventRequest(
    string? Name,
    string? Description,
    string? Address,
    string? City,
    string? Country,
    string? Zip,
    string? State,
    bool? EveryoneAllowed);
