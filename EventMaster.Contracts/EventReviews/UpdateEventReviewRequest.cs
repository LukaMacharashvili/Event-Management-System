namespace EventMaster.Contracts.EventReviews;

public record UpdateEventReviewRequest(
    string? Title,
    string? Description,
    int? Stars);
