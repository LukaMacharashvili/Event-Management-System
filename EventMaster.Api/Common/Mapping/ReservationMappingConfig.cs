using Mapster;
using EventMaster.Application.Reservations.Commands.CreateReservation;
using EventMaster.Contracts.Reservations;
using EventMaster.Application.Reservations.Commands.DeleteReservation;
using EventMaster.Application.Reservations.Queries.FetchReservation;
using EventMaster.Application.Reservations.Queries.LoadReservations;

namespace EventMaster.Api.Common.Mapping;

public class ReservationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {

        config.NewConfig<int, LoadReservationsQuery>()
            .Map(dest => dest.GuestId, src => src);

        config.NewConfig<int, FetchReservationQuery>()
            .Map(dest => dest.ReservationId, src => src);

        config.NewConfig<CreateReservationAndGuestIdAndTicketId, CreateReservationCommand>()
            .Map(dest => dest.GuestId, src => src.GuestId)
            .Map(dest => dest, src => src.Request);

        config.NewConfig<DeleteReservationAndGuestIdAndEventId, DeleteReservationCommand>()
            .Map(dest => dest.ReservationId, src => src.ReservationId)
            .Map(dest => dest.EventId, src => src.EventId)
            .Map(dest => dest.GuestId, src => src.GuestId);
    }
}

public record CreateReservationAndGuestIdAndTicketId(int GuestId, CreateReservationRequest Request);

public record DeleteReservationAndGuestIdAndEventId(int ReservationId, int GuestId, int EventId);
