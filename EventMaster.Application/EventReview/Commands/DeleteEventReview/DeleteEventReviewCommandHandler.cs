using EventMaster.Application.Common.Interfaces.Persistence;
using ErrorOr;
using MediatR;
using EventMaster.Domain.Common.DomainErrors;
using EventMaster.Domain.EventReviews;

namespace EventMaster.Application.EventReviews.Commands.DeleteEventReview;

public class DeleteEventReviewCommandHandler : IRequestHandler<DeleteEventReviewCommand, ErrorOr<EventReview>>
{
    private readonly IEventReviewRepository _eventReviewRepository;
    private readonly IUserRepository _userRepository;

    public DeleteEventReviewCommandHandler(IUserRepository userRepository,
        IEventReviewRepository eventReviewRepository)
    {
        _eventReviewRepository = eventReviewRepository;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<EventReview>> Handle(DeleteEventReviewCommand request, CancellationToken cancellationToken)
    {
        var eventReview = await _eventReviewRepository.FetchAsync(request.EventReviewId);
        if (eventReview is null)
        {
            return Errors.EventReview.EventReviewNotFound;
        }

        if (eventReview.GuestId != request.GuestId)
        {
            return Errors.Guest.GuestNotAllowed;
        }

        await _eventReviewRepository.DeleteAsync(eventReview);

        return eventReview;
    }
}