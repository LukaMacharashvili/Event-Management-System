using EventMaster.Application.Common.Interfaces.Persistence;
using ErrorOr;
using MediatR;
using EventMaster.Domain.Common.DomainErrors;
using EventMaster.Domain.EventReviews;

namespace EventMaster.Application.EventReviews.Commands.CreateEventReview;

public class CreateEventReviewCommandHandler : IRequestHandler<CreateEventReviewCommand, ErrorOr<EventReview>>
{
    private readonly IEventReviewRepository _eventReviewRepository;
    private readonly IEventRepository _eventRepository;
    private readonly IUserRepository _guestRepository;

    public CreateEventReviewCommandHandler(IEventReviewRepository eventReviewRepository,
    IUserRepository guestRepository,
    IEventRepository eventRepository)
    {
        _eventReviewRepository = eventReviewRepository;
        _guestRepository = guestRepository;
        _eventRepository = eventRepository;
    }

    public async Task<ErrorOr<EventReview>> Handle(CreateEventReviewCommand request, CancellationToken cancellationToken)
    {
        var guest = await _guestRepository.FetchAsync(request.GuestId);
        if (guest is null)
        {
            return Errors.Guest.GuestNotFound;
        }

        var @event = await _eventRepository.FetchAsync(request.EventId);
        if (@event is null)
        {
            return Errors.Event.EventNotFound;
        }

        if (@event.Guests.FirstOrDefault(x => x.GuestId == request.GuestId) is null)
        {
            return Errors.Guest.GuestNotAllowed;
        }

        var eventReview = EventReview.Create(
            guest,
            @event,
            request.Title,
            request.Description,
            request.Stars);

        await _eventReviewRepository.AddAsync(eventReview);

        return eventReview;
    }
}