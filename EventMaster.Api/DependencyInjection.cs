using System.Text.Json.Serialization;
using EventMaster.Api.Common.Errors;
using EventMaster.Api.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace EventMaster.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
        services.AddHttpContextAccessor();
        services.AddSingleton<ProblemDetailsFactory, EventMasterProblemDetailsFactory>();
        services.AddMappings();
        return services;
    }
}