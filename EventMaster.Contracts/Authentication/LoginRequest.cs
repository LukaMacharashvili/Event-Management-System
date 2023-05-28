namespace EventMaster.Contracts.Authentication;

public record LoginUserRequest(
    string Email,
    string Password,
    string ClientId);