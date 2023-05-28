using Mapster;
using EventMaster.Application.EventReviews.Commands.CreateEventReview;
using EventMaster.Contracts.EventReviews;
using EventMaster.Application.EventReviews.Commands.DeleteEventReview;
using EventMaster.Application.EventReviews.Queries.FetchEventReview;
using EventMaster.Application.EventReviews.Commands.UpdateEventReview;
using EventMaster.Application.EventReviews.Queries.LoadEventReviews;

namespace EventMaster.Api.Common.Mapping;

public class EventReviewMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {

        config.NewConfig<int, LoadEventReviewsQuery>()
            .Map(dest => dest.EventId, src => src);

        config.NewConfig<int, FetchEventReviewQuery>()
            .Map(dest => dest.EventReviewId, src => src);

        config.NewConfig<CreateEventReviewAndGuestIdAndEventId, CreateEventReviewCommand>()
            .Map(dest => dest.GuestId, src => src.GuestId)
            .Map(dest => dest.EventId, src => src.EventId)
            .Map(dest => dest, src => src.Request);

        config.NewConfig<UpdateEventReviewAndGuestIdAndEventReviewId, UpdateEventReviewCommand>()
            .Map(dest => dest.EventReviewId, src => src.EventReviewId)
            .Map(dest => dest.GuestId, src => src.GuestId)
            .Map(dest => dest, src => src.Request);

        config.NewConfig<DeleteEventReviewAndGuestId, DeleteEventReviewCommand>()
            .Map(dest => dest.EventReviewId, src => src.EventReviewId)
            .Map(dest => dest.GuestId, src => src.GuestId);
    }
}

public record CreateEventReviewAndGuestIdAndEventId(int GuestId, int EventId, CreateEventReviewRequest Request);

public record UpdateEventReviewAndGuestIdAndEventReviewId(int EventReviewId, int GuestId, UpdateEventReviewRequest Request);

public record DeleteEventReviewAndGuestId(int EventReviewId, int GuestId);
