using EventMaster.Application.Topics.Commands.CreateTopic;
using EventMaster.Application.Topics.Commands.DeleteTopic;
using EventMaster.Application.Topics.Commands.UpdateTopic;
using EventMaster.Application.Topics.Queries.FetchTopic;
using EventMaster.Application.Topics.Queries.LoadTopics;
using EventMaster.Contracts.Topics;
using Mapster;

namespace EventMaster.Api.Common.Mapping;

public class TopicMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<int, LoadTopicsQuery>()
            .Map(dest => dest.EventId, src => src);

        config.NewConfig<int, FetchTopicQuery>()
            .Map(dest => dest.TopicId, src => src);

        config.NewConfig<CreateTopicAndHostIdAndEventId, CreateTopicCommand>()
            .Map(dest => dest.HostId, src => src.HostId)
            .Map(dest => dest.EventId, src => src.EventId)
            .Map(dest => dest, src => src.Request);

        config.NewConfig<UpdateTopicAndHostIdAndEventIdAndTopicId, UpdateTopicCommand>()
            .Map(dest => dest.TopicId, src => src.TopicId)
            .Map(dest => dest.HostId, src => src.HostId)
            .Map(dest => dest.EventId, src => src.EventId)
            .Map(dest => dest, src => src.Request);

        config.NewConfig<DeleteTopicAndHostIdAndEventIdAndTopicId, DeleteTopicCommand>()
            .Map(dest => dest.TopicId, src => src.TopicId)
            .Map(dest => dest.HostId, src => src.HostId)
            .Map(dest => dest.EventId, src => src.EventId);
    }
}

public record CreateTopicAndHostIdAndEventId(int HostId, int EventId, CreateTopicRequest Request);

public record UpdateTopicAndHostIdAndEventIdAndTopicId(int HostId, int EventId, int TopicId, UpdateTopicRequest Request);

public record DeleteTopicAndHostIdAndEventIdAndTopicId(int HostId, int EventId, int TopicId);