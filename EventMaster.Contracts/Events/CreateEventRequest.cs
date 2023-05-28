namespace EventMaster.Contracts.Events;

public record CreateEventRequest(
    string Name,
    string Description,
    string Address,
    string City,
    string Country,
    string Zip,
    string? State,
    bool EveryoneAllowed);
