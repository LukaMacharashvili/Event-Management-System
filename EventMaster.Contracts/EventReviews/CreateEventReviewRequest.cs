namespace EventMaster.Contracts.EventReviews;

public record CreateEventReviewRequest(
    string Title,
    string Description,
    int Stars);
