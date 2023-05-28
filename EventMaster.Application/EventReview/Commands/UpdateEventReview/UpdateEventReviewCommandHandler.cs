using EventMaster.Application.Common.Interfaces.Persistence;
using ErrorOr;
using MediatR;
using EventMaster.Domain.Common.DomainErrors;
using EventMaster.Domain.EventReviews;

namespace EventMaster.Application.EventReviews.Commands.UpdateEventReview;

public class UpdateEventReviewCommandHandler : IRequestHandler<UpdateEventReviewCommand, ErrorOr<EventReview>>
{
    private readonly IEventReviewRepository _eventReviewRepository;

    public UpdateEventReviewCommandHandler(IEventReviewRepository eventReviewRepository)
    {
        _eventReviewRepository = eventReviewRepository;
    }

    public async Task<ErrorOr<EventReview>> Handle(UpdateEventReviewCommand request, CancellationToken cancellationToken)
    {
        var eventReview = await _eventReviewRepository.FetchAsync(request.EventReviewId);
        if (eventReview is null)
        {
            return Errors.EventReview.EventReviewNotFound;
        }

        if (eventReview.GuestId != request.GuestId)
        {
            return Errors.EventReview.EventReviewNotFound;
        }

        eventReview.Update(request.Title, request.Description, request.Stars);

        await _eventReviewRepository.UpdateAsync(eventReview);

        return eventReview;
    }
}