using Mapster;
using EventMaster.Application.Tickets.Commands.CreateTicket;
using EventMaster.Contracts.Tickets;
using EventMaster.Application.Tickets.Commands.DeleteTicket;
using EventMaster.Application.Tickets.Queries.FetchTicket;
using EventMaster.Application.Tickets.Queries.LoadTickets;

namespace EventMaster.Api.Common.Mapping;

public class TicketMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {

        config.NewConfig<int, LoadTicketsQuery>()
            .Map(dest => dest.EventId, src => src);

        config.NewConfig<int, FetchTicketQuery>()
            .Map(dest => dest.TicketId, src => src);

        config.NewConfig<CreateTicketAndHostIdAndEventId, CreateTicketCommand>()
            .Map(dest => dest.HostId, src => src.HostId)
            .Map(dest => dest.EventId, src => src.EventId)
            .Map(dest => dest, src => src.Request);

        config.NewConfig<DeleteTicketAndHostIdAndEventId, DeleteTicketCommand>()
            .Map(dest => dest.TicketId, src => src.TicketId)
            .Map(dest => dest.EventId, src => src.EventId)
            .Map(dest => dest.HostId, src => src.HostId);
    }
}

public record CreateTicketAndHostIdAndEventId(int HostId, int EventId, CreateTicketRequest Request);

public record DeleteTicketAndHostIdAndEventId(int TicketId, int HostId, int EventId);
