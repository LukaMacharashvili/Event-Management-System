namespace EventMaster.Contracts.Authentication;

public record RegisterUserRequest(
    string FirstName,
    string LastName,
    string Email,
    string Password,
    string ClientId);