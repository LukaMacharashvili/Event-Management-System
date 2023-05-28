using Mapster;
using EventMaster.Application.Events.Commands.CreateEvent;
using EventMaster.Contracts.Events;
using EventMaster.Application.Events.Commands.DeleteEvent;
using EventMaster.Application.Events.Queries.FetchEvent;
using EventMaster.Application.Events.Commands.UpdateEvent;

namespace EventMaster.Api.Common.Mapping;

public class EventMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<int, FetchEventQuery>()
            .Map(dest => dest.EventId, src => src);

        config.NewConfig<CreateEventAndHostId, CreateEventCommand>()
            .Map(dest => dest.HostId, src => src.HostId)
            .Map(dest => dest, src => src.Request);

        config.NewConfig<UpdateEventAndHostIdAndEventId, UpdateEventCommand>()
            .Map(dest => dest.EventId, src => src.EventId)
            .Map(dest => dest.HostId, src => src.HostId)
            .Map(dest => dest, src => src.Request);

        config.NewConfig<DeleteEventAndHostId, DeleteEventCommand>()
            .Map(dest => dest.EventId, src => src.EventId)
            .Map(dest => dest.HostId, src => src.HostId);
    }
}

public record CreateEventAndHostId(int HostId, CreateEventRequest Request);

public record UpdateEventAndHostIdAndEventId(int EventId, int HostId, UpdateEventRequest Request);

public record DeleteEventAndHostId(int EventId, int HostId);
